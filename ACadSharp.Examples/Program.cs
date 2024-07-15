using ACadSharp.Entities;
using ACadSharp.IO;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using CSMath;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ACadSharp.Examples
{
	class Program
	{
		const string _file = "C:\\Users\\vovam\\Downloads\\Showroom Drafting1.dwg";

		static void Main(string[] args)
		{
			CadDocument doc;
			using (DwgReader reader = new DwgReader(_file))
			{
				doc = reader.Read();
			}
			exploreDocument(doc);
			TestArtem(doc);
			Console.ReadLine();
		}

		/// <summary>
		/// Logs in the console the document information
		/// </summary>
		/// <param name="doc"></param>
		static void exploreDocument(CadDocument doc)
		{
			Console.WriteLine();
			Console.WriteLine("SUMMARY INFO:");
			Console.WriteLine($"\tTitle: {doc.SummaryInfo.Title}");
			Console.WriteLine($"\tSubject: {doc.SummaryInfo.Subject}");
			Console.WriteLine($"\tAuthor: {doc.SummaryInfo.Author}");
			Console.WriteLine($"\tKeywords: {doc.SummaryInfo.Keywords}");
			Console.WriteLine($"\tComments: {doc.SummaryInfo.Comments}");
			Console.WriteLine($"\tLastSavedBy: {doc.SummaryInfo.LastSavedBy}");
			Console.WriteLine($"\tRevisionNumber: {doc.SummaryInfo.RevisionNumber}");
			Console.WriteLine($"\tHyperlinkBase: {doc.SummaryInfo.HyperlinkBase}");
			Console.WriteLine($"\tCreatedDate: {doc.SummaryInfo.CreatedDate}");
			Console.WriteLine($"\tModifiedDate: {doc.SummaryInfo.ModifiedDate}");

			exploreTable(doc.AppIds);
			exploreTable(doc.BlockRecords);
			exploreTable(doc.DimensionStyles);
			exploreTable(doc.Layers);
			exploreTable(doc.LineTypes);
			exploreTable(doc.TextStyles);
			exploreTable(doc.UCSs);
			exploreTable(doc.Views);
			exploreTable(doc.VPorts);

		}


		static void TestArtem(CadDocument doc)
		{
			var lE = new Dictionary<string, Entity>();
			var l = new List<Entity>();
			var textL = new Dictionary<string, List<Entity>>();
			var textM = new Dictionary<string, List<MText>>();

			var roomLabel = doc.Layers.FirstOrDefault(l => l.Name == "Room Lable");
			var roomLabelEntities = new List<Entity>();
			var eTypeValueEntity = new Dictionary<ObjectType, List<Entity>>();



			var layEntiTypeEntity = new Dictionary<string, Dictionary<ObjectType, List<Entity>>>();


			var cEntite = doc.Entities.Where(x => x.Layer.Name == "Circuitry");

			foreach (var entity in doc.Entities)
			{
				var lName = entity.Layer.Name;
				if (!layEntiTypeEntity.ContainsKey(lName))
				{
					layEntiTypeEntity.Add(lName, new Dictionary<ObjectType, List<Entity>>());
				}

				var dOE = layEntiTypeEntity[lName];
				if (!dOE.ContainsKey(entity.ObjectType))
				{
					dOE.Add(entity.ObjectType, new List<Entity>());
				}
				dOE[entity.ObjectType].Add(entity);

				if (!eTypeValueEntity.ContainsKey(entity.ObjectType))
				{
					eTypeValueEntity.Add(entity.ObjectType, new List<Entity>());
				}
				eTypeValueEntity[entity.ObjectType].Add(entity);
				if (entity is TextEntity)
				{
					var text = (TextEntity)entity;

					if (!textL.ContainsKey(text.Value))
					{
						textL.Add(text.Value, new List<Entity>());
					}
					textL[text.Value].Add(entity);
				}
				if (entity is MText)
				{
					var text = (MText)entity;

					if (!textM.ContainsKey(text.Value))
					{
						textM.Add(text.Value, new List<MText>());
					}
					textM[text.Value].Add((text));
				}

				if (entity.Layer == roomLabel)
				{
					roomLabelEntities.Add(entity);
				}
			}
			/*var lines = layEntiTypeEntity["0-CountArea"].Values.First();
			var pLines = new List<List<LwPolyline.Vertex>>();
			foreach (var line in lines)
			{
				pLines.Add(((ACadSharp.Entities.LwPolyline)line).Vertices);
			}

			var roomVertices = GetRoomVertices(layEntiTypeEntity);
			var nRI=new Dictionary<string, int>();
			var pointV = (MText)layEntiTypeEntity["A-LABEL-GF"].Values.First().First();
			foreach (MText room in layEntiTypeEntity["A-LABEL-GF"].Values.First())
			{
			//	pLines, new CSMath.XYZ(point1.InsertPoint.X + (point1.RectangleWidth / 2), point1.InsertPoint.Y, point1.InsertPoint.Z

				nRI.Add(room.Value, EnterInRoomIndexes(roomVertices, new XYZ(room.InsertPoint.X+(room.RectangleWidth/2),room.InsertPoint.Y,room.InsertPoint.Z)));
			}
			var point = pointV.InsertPoint;
			var indexOfRoom = EnterInRoomIndexes(roomVertices, point);
			var r = textL.OrderBy(x => x.Value.Count()).ToList();*/
			var lines = layEntiTypeEntity["0-CountArea"].Values.First();
			var pLines = new List<List<LwPolyline.Vertex>>();
			foreach (var line in lines)
			{
				pLines.Add(((ACadSharp.Entities.LwPolyline)line).Vertices);
			}

			var pointV = (MText)layEntiTypeEntity["A-LABEL-GF"].Values.First().First();
			var point = pointV.InsertPoint;
			var indexOfRoom = EnterInRoomIndexes(pLines, point);

			var findRoom = new Dictionary<string, int>();

			var allRooms = layEntiTypeEntity["A-LABEL-GF"].Values.First().ToList();
			allRooms.AddRange(layEntiTypeEntity["A-LABEL-FF"].Values.First().ToList());

			foreach (MText point1 in allRooms)
			{
				findRoom.Add(point1.Value, EnterInRoomIndexes(pLines, new CSMath.XYZ(point1.InsertPoint.X + (point1.RectangleWidth / 2), point1.InsertPoint.Y, point1.InsertPoint.Z)));
			}
			var roomVertices = GetRoomVertices(layEntiTypeEntity);
			var pBlockCountInRooms = CountPBlockInRooms(layEntiTypeEntity, roomVertices);

			foreach (var room in pBlockCountInRooms)
			{
				Console.WriteLine($"Room: {room.Key}");
				foreach (var pBlock in room.Value)
				{
					Console.WriteLine($"\tP-BLOCK {pBlock.Key}: {pBlock.Value}");
				}
			}
			var r = textL.OrderBy(x => x.Value.Count()).ToList();
		}
		static Dictionary<string, List<LwPolyline.Vertex>> GetRoomVertices(Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity)
		{
			var result = new Dictionary<string, List<LwPolyline.Vertex>>();
			var lines = layEntiTypeEntity["0-CountArea"].Values.First();
			var labels = layEntiTypeEntity["A-LABEL-GF"].Values.First();
			labels.AddRange(layEntiTypeEntity["A-LABEL-FF"].Values.First());
			foreach (var label in labels.OfType<MText>())
			{
				var labelPoint = label.InsertPoint;
				foreach (var line in lines.OfType<LwPolyline>())
				{
					if (IsPointInPolyline(labelPoint, line))
					{
						result[label.Value] = line.Vertices;
						break;
					}
				}
			}

			return result;
		}
		static Dictionary<string, Dictionary<string, int>> CountPBlockInRooms(
		   Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity,
		   Dictionary<string, List<LwPolyline.Vertex>> roomVertices)
		{
			var result = new Dictionary<string, Dictionary<string, int>>();
			var pBlocks = layEntiTypeEntity["P-BLOCK"].Values.First().OfType<MText>().ToList();

			foreach (var pBlock in pBlocks)
			{
				var pBlockPoint = pBlock.InsertPoint;

				foreach (var room in roomVertices)
				{
					var roomName = room.Key;
					var vertices = room.Value;

					if (IsPointInPolyline(pBlockPoint, new LwPolyline { Vertices = vertices }))
					{
						if (!result.ContainsKey(roomName))
						{
							result[roomName] = new Dictionary<string, int>();
						}

						var pBlockValue = pBlock.Value;

						if (result[roomName].ContainsKey(pBlockValue))
						{
							result[roomName][pBlockValue]++;
						}
						else
						{
							result[roomName][pBlockValue] = 1;
						}
					}
				}
			}

			return result;
		}
		static bool IsPointInPolyline(XYZ point, LwPolyline polyline)
		{
			var vertices = polyline.Vertices;
			bool isInside = false;

			double xMin = vertices.Min(v => v.Location.X);
			double xMax = vertices.Max(v => v.Location.X);
			double yMin = vertices.Min(v => v.Location.Y);
			double yMax = vertices.Max(v => v.Location.Y);

			Console.WriteLine($"Checking point: ({point.X}, {point.Y}) against polyline with {vertices.Count} vertices.");

			if (point.X < xMin || point.X > xMax || point.Y < yMin || point.Y > yMax)
			{
				Console.WriteLine($"Point ({point.X}, {point.Y}) is outside bounding box of polyline.");
				return false;
			}

			for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
			{
				var xi = vertices[i].Location.X;
				var yi = vertices[i].Location.Y;
				var xj = vertices[j].Location.X;
				var yj = vertices[j].Location.Y;

				Console.WriteLine($"Vertex {i}: ({xi}, {yi}) - Vertex {j}: ({xj}, {yj})");

				if ((yi > point.Y) != (yj > point.Y) && (point.X < (xj - xi) * (point.Y - yi) / (yj - yi) + xi))
				{
					isInside = !isInside;
				}
			}

			Console.WriteLine($"Point ({point.X}, {point.Y}) is inside polyline: {isInside}");
			return isInside;
		}


		/*static int EnterInRoomIndexes(Dictionary<string, List<LwPolyline.Vertex>> roomVertices, XYZ point)
		{
			foreach (var room in roomVertices)
			{
				var vertices = room.Value;
				var xMin = vertices.Min(v => v.Location.X);
				var xMax = vertices.Max(v => v.Location.X);
				var yMin = vertices.Min(v => v.Location.Y);
				var yMax = vertices.Max(v => v.Location.Y);

				if (xMin <= point.X && xMax >= point.X && yMin <= point.Y && yMax >= point.Y)
				{
					return roomVertices.Keys.ToList().IndexOf(room.Key);
				}
			}

			return -1;
		}*/
		static int EnterInRoomIndexes(List<List<LwPolyline.Vertex>> vertexs, CSMath.XYZ point)
		{
			int result = -1;
			for (int i = 0; i < vertexs.Count; i++)
			{
				var xMin = vertexs[i].Min(x => x.Location.X);
				var xMax = vertexs[i].Max(x => x.Location.X);
				var yMin = vertexs[i].Min(x => x.Location.Y);
				var yMax = vertexs[i].Max(x => x.Location.Y);


				if (xMin <= point.X
					&& xMax >= point.X
					&& yMin <= point.Y
					&& yMax >= point.Y)
				{
					result = i;
					break;
				}
			}

			return result;
		}
		static void exploreTable<T>(Table<T> table)
			where T : TableEntry
		{
			Console.WriteLine($"{table.ObjectName}");
			foreach (var item in table)
			{
				Console.WriteLine($"\tName: {item.Name}");

				if (item.Name == BlockRecord.ModelSpaceName && item is BlockRecord model)
				{
					Console.WriteLine($"\t\tEntities in the model:");
					foreach (var e in model.Entities.GroupBy(i => i.GetType().FullName))
					{
						Console.WriteLine($"\t\t{e.Key}: {e.Count()}");
					}
				}
			}
		}
	}
}