using ACadSharp.Entities;
using ACadSharp.IO;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using CSMath;
using OneByMartinDoller.Shared.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ACadSharp.Examples
{
	public static class Program
	{
		const string _file = "C:\\Users\\belbo\\Downloads\\Showroom Drafting (4).dwg";

		static void Main(string[] args)
		{
			CadDocument doc;
			using (DwgReader reader = new DwgReader(_file))
			{
				doc = reader.Read();
			}
			//exploreDocument(doc);
			//TestArtem(doc);
			//GeneratePolyLines(doc);
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
				var cleanedRoomName = CleanRoomName(room.Key);
				Console.WriteLine($"Room: {cleanedRoomName}");
				foreach (var pBlock in room.Value)
				{
					var cleanedKey = ExtractLastValue(pBlock.Key);
					Console.WriteLine($"\tP-BLOCK {cleanedKey}: {pBlock.Value}");
				}
			}

			Console.WriteLine(ExtractLastValue("{\fYu Gothic UI Semibold|b1|i0|c128|p34;BB}X{\fYu Gothic UI Semibold|b1|i0|c128|p34;13}"));

			var r = textL.OrderBy(x => x.Value.Count()).ToList();
		}
		public static Dictionary<DGWViewModel, List<LwPolyline.Vertex>> GetRoomVertices(Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity)
		{
			var result = new Dictionary<DGWViewModel, List<LwPolyline.Vertex>>();

			var polygons = layEntiTypeEntity.ContainsKey("0-CountArea")
							? layEntiTypeEntity["0-CountArea"].Values.SelectMany(e => e.OfType<LwPolyline>()).ToList()
							: new List<LwPolyline>();

			var labels = new List<MText>();
			if (layEntiTypeEntity.ContainsKey("A-LABEL-GF"))
			{
				var groundFloor = layEntiTypeEntity["A-LABEL-GF"].Values.SelectMany(e => e.OfType<MText>());
				foreach (var item in ExtractRoomCuirtis(polygons, groundFloor, FloorTypes.GroundFloor))
				{
					result.Add(item.Key, item.Value);
				};
			}
			if (layEntiTypeEntity.ContainsKey("A-LABEL-FF"))
			{
				var firstFloor = layEntiTypeEntity["A-LABEL-FF"].Values.SelectMany(e => e.OfType<MText>());
				foreach (var item in ExtractRoomCuirtis(polygons, firstFloor, FloorTypes.FirstFloor))
				{
					result.Add(item.Key, item.Value);
				};
			}


			return result;
		}

		private static Dictionary<DGWViewModel, List<LwPolyline.Vertex>> ExtractRoomCuirtis(List<LwPolyline> polygons, IEnumerable<MText> labels, FloorTypes floorType)
		{
			var result = new Dictionary<DGWViewModel, List<LwPolyline.Vertex>>();
			foreach (var label in labels)
			{
				label.Value = CleanRoomName(label.Value);
				var labelPoint = label.InsertPoint;
				foreach (var polygon in polygons)
				{
					if (IsPointInPolyline(new CSMath.XYZ(labelPoint.X + (label.RectangleWidth / 2), labelPoint.Y, labelPoint.Z), polygon))
					{
						result.Add(new DGWViewModel() { FloorType = floorType, RoomName = label.Value }, polygon.Vertices);
						break;
					}
				}

			}
			return result;
		}

		public static Dictionary<string, Dictionary<string, int>> CountPBlockInRooms(
	Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity,
	Dictionary<DGWViewModel, List<LwPolyline.Vertex>> roomVertices)
		{
			var result = new Dictionary<string, Dictionary<string, int>>();


			if (!layEntiTypeEntity.ContainsKey("P-BLOCK"))
			{
				throw new KeyNotFoundException("The given key 'P-BLOCK' was not present in the dictionary.");
			}


			var pBlocks = layEntiTypeEntity["P-BLOCK"].First().Value.OfType<MText>().ToList();

			var outRooms = new List<MText>();
			foreach (var pBlock in pBlocks)
			{
				var pBlockPoint = pBlock.InsertPoint;
				var isInRoom = false;


				foreach (var room in roomVertices)
				{
					var roomName = room.Key.RoomName;
					var vertices = room.Value;

					if (IsPointInPolyline(pBlockPoint, new LwPolyline { Vertices = vertices }))
					{
						isInRoom = true;
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
						break;
					}
				}

				if (!isInRoom)
				{
					outRooms.Add(pBlock);
				}
			}

			if (layEntiTypeEntity.ContainsKey("E-LUM-CIRC"))
			{
				var lumCircEntities = layEntiTypeEntity["E-LUM-CIRC"];
				foreach (var outRoom in outRooms)
				{
					var pBlockValue = outRoom.Value;
					var point = outRoom.InsertPoint;
					LwPolyline containingRectangle = null;


					foreach (var entity in lumCircEntities.Values.ElementAt(1))
					{
						if (entity is LwPolyline rectangle && IsPointInPolyline(point, rectangle))
						{
							containingRectangle = rectangle;
							break;
						}
					}

					if (containingRectangle != null)
					{

						foreach (var entity in lumCircEntities.Values.ElementAt(0))
						{
							if (entity is Line line)
							{

								var startPoint = new CSMath.XYZ(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
								var endPoint = new CSMath.XYZ(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);

								foreach (var room in roomVertices)
								{
									var roomName = room.Key.RoomName;
									var vertices = room.Value;

									if (IsPointInPolyline(startPoint, new LwPolyline { Vertices = vertices }) ||
										IsPointInPolyline(endPoint, new LwPolyline { Vertices = vertices }))
									{
										if (!result.ContainsKey(roomName))
										{
											result[roomName] = new Dictionary<string, int>();
										}

										if (result[roomName].ContainsKey(pBlockValue))
										{
											result[roomName][pBlockValue]++;
										}
										else
										{
											result[roomName][pBlockValue] = 1;
										}

										break;
									}
								}
							}
						}
					}
				}
			}

			return result;
		}




		public static string ExtractLastValue(string input)
		{
			int startBracketIndex = input.IndexOf('{');
			int semicolonIndex = input.IndexOf(';');
			int closingBracketIndex = input.IndexOf('}');
			string result = string.Empty;

			if (startBracketIndex >= 0 && semicolonIndex >= 0 && closingBracketIndex > semicolonIndex)
			{
				string firstChar = string.Empty;
				string secondChar = string.Empty;

				if (startBracketIndex > 0)
				{

					firstChar = input.Substring(0, startBracketIndex);
					if (firstChar.Contains('\\'))
					{
						input = input.Remove(0, startBracketIndex);
						semicolonIndex = input.IndexOf(';');
						input = input.Remove(0, semicolonIndex + 1);
						int backSlashIndex = input.IndexOf('\\');
						firstChar = input.Substring(0, backSlashIndex);
						backSlashIndex = input.IndexOf("\\S");
						input = input.Remove(0, backSlashIndex + 2);
						int squareIndex = input.IndexOf("^");
						result = input.Substring(0, squareIndex);

						result = ConvertToSuperscript(result);



					}
					else
					{
						result = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1).Trim();
					}

				}
				else if (startBracketIndex == 0)
				{
					firstChar = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1);
					input = input.Remove(0, closingBracketIndex + 1);
					if (input.Length > 1)
					{
						startBracketIndex = input.IndexOf('{');
						closingBracketIndex = input.IndexOf('}');
						semicolonIndex = input.IndexOf(';');
						secondChar = input.Substring(0, startBracketIndex);
						result = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1).Trim();




					}
					else
					{
						result = input;
					}

				}
				if (firstChar != string.Empty)
				{
					if (secondChar == string.Empty)
					{
						return $"{firstChar}{result}";
					}
					else
					{
						return $"{firstChar}{secondChar}{result}";
					}
				}
			}

			return input;
		}
		public static string ConvertToSuperscript(string input)
		{
			StringBuilder result = new StringBuilder();
			foreach (char c in input)
			{
				result.Append(CharToSuperscript(c));
			}
			return result.ToString();
		}

		public static string CharToSuperscript(char c)
		{
			switch (c)
			{
				case '0': return "\u2070";
				case '1': return "\u00B9";
				case '2': return "\u00B2";
				case '3': return "\u00B3";
				case '4': return "\u2074";
				case '5': return "\u2075";
				case '6': return "\u2076";
				case '7': return "\u2077";
				case '8': return "\u2078";
				case '9': return "\u2079";
				case 'a': return "\u1D43";
				case 'b': return "\u1D47";
				case 'c': return "\u1D9C";
				case 'd': return "\u1D48";
				case 'e': return "\u1D49";
				case 'f': return "\u1DA0";
				case 'g': return "\u1D4D";
				case 'h': return "\u02B0";
				case 'i': return "\u2071";
				case 'j': return "\u02B2";
				case 'k': return "\u1D4F";
				case 'l': return "\u02E1";
				case 'm': return "\u1D50";
				case 'n': return "\u207F";
				case 'o': return "\u1D52";
				case 'p': return "\u1D56";
				case 'q': return "\u02A0";
				case 'r': return "\u02B3";
				case 's': return "\u02E2";
				case 't': return "\u1D57";
				case 'u': return "\u1D58";
				case 'v': return "\u1D5B";
				case 'w': return "\u02B7";
				case 'x': return "\u02E3";
				case 'y': return "\u02B8";
				case 'z': return "\u1DBB";
				default: return c.ToString();
			}
		}
		public static string CleanRoomName(string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException(nameof(input), "Input cannot be null.");
			}


			if (input.Contains(@"\pxqc;"))
			{

				string result = input.Replace(@"\pxqc;", string.Empty);
				return result;
			}

			return input;
		}

		public static bool IsPointInPolyline(XY point, LwPolyline polyline, int step)
		{
			return IsPointInPolyline(new XYZ(point.X, point.Y, 0), polyline, step);
		}

		public static bool IsPointInPolyline(XYZ point, LwPolyline polyline, int step)
		{
			XYZ xYZ1 = new XYZ(point.X + step, point.Y + step, 0);
			XYZ xYZ2 = new XYZ(point.X - step, point.Y - step, 0);

			XYZ xYZ3 = new XYZ(point.X + step, point.Y, 0);
			XYZ xYZ4 = new XYZ(point.X, point.Y - step, 0);

			var original = IsPointInPolyline(point, polyline);
			if (original)
				return original;
			var bouthAdded = IsPointInPolyline(xYZ1, polyline);
			if (bouthAdded) return bouthAdded;

			var bouthMinus = IsPointInPolyline(xYZ2, polyline);
			if (bouthMinus) return bouthMinus;

			var xAdded = IsPointInPolyline(xYZ3, polyline);
			if (xAdded) return xAdded;

			var yAdded = IsPointInPolyline(xYZ4, polyline);
			if (yAdded) return yAdded;

			return false;
		}

		public static bool IsPointInPolyline(XYZ point, LwPolyline polyline)
		{
			var vertices = polyline.Vertices;
			bool isInside = false;

			double xMin = vertices.Min(v => v.Location.X);
			double xMax = vertices.Max(v => v.Location.X);
			double yMin = vertices.Min(v => v.Location.Y);
			double yMax = vertices.Max(v => v.Location.Y);



			if (point.X < xMin || point.X > xMax || point.Y < yMin || point.Y > yMax)
			{

				return false;
			}

			for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
			{
				var xi = vertices[i].Location.X;
				var yi = vertices[i].Location.Y;
				var xj = vertices[j].Location.X;
				var yj = vertices[j].Location.Y;



				if ((yi > point.Y) != (yj > point.Y) && (point.X < (xj - xi) * (point.Y - yi) / (yj - yi) + xi))
				{
					isInside = !isInside;
				}
			}

			return isInside;
		}
		public static int EnterInRoomIndexes(List<List<LwPolyline.Vertex>> vertexs, CSMath.XYZ point)
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
		public static void exploreTable<T>(Table<T> table)
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