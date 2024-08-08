using ACadSharp;
using ACadSharp.Entities;
using OneByMartinDoller.Shared.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMath;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using OneByMartinDoller.Shared.Model;

namespace OneByMartinDoller.Shared.Services
{
	public class DwgProccesingService : IDwgProccessingService
	{
		public string ExtractLastValue(string input)
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
						if (startBracketIndex - semicolonIndex > 1)
						{
							firstChar = input.Substring(semicolonIndex + 1, startBracketIndex - semicolonIndex - 1);
							input = input.Remove(0, startBracketIndex);
							semicolonIndex = input.IndexOf(';');
							input = input.Remove(0, semicolonIndex + 1);
							int backSlashIndex = input.IndexOf('\\');
							backSlashIndex = input.IndexOf("\\S");
							input = input.Remove(0, backSlashIndex + 2);
							int squareIndex = input.IndexOf("^");
							result = input.Substring(0, squareIndex);

							result = ConvertToSuperscript(result);
						}
						else
						{
							try
							{
					
								if (input.Remove(0, closingBracketIndex+1) != "")
								{
									input = input.Remove(0, closingBracketIndex + 1);
									startBracketIndex = input.IndexOf("{");
									firstChar = input.Substring(0, startBracketIndex);
									int backSlashIndex = input.IndexOf("\\S");
									input = input.Remove(0, backSlashIndex + 2);
									int squareIndex = input.IndexOf("^");
									result = input.Substring(0, squareIndex);

									result = ConvertToSuperscript(result);
								}
								else
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

							}
							catch(Exception e)
							{
								Console.WriteLine(e);
							}

						}

					}
					else
					{
						result = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1).Trim();
					}
				}
				else if (startBracketIndex == 0)
				{
					if (input.Contains("{["))
					{
						input = input.Remove(0, semicolonIndex + 1);
						firstChar = input[0].ToString();
						int backSlashIndex = input.IndexOf("\\S");
						input = input.Remove(0, backSlashIndex + 2);
						int squareIndex = input.IndexOf("^");
						result = ConvertToSuperscript(input.Substring(0, squareIndex));

					}
					else
					{
						firstChar = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1);
						input = input.Remove(0, closingBracketIndex + 1);
						if (input.Length > 1)
						{
							if (input.Contains("{") && input.Contains("}") && input.Contains(";"))
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
						else
						{
							result = input;
						}
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


		public string ConvertToSuperscript(string input)
		{
			StringBuilder result = new StringBuilder();
			foreach (char c in input)
			{
				result.Append(CharToSuperscript(c));
			}
			return result.ToString();
		}

		public string CharToSuperscript(char c)
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

		public string CleanRoomName(string input)
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
		public Dictionary<string, Dictionary<string, int>> GetProccessing(CadDocument doc)
		{
			Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity = GetlayEntiTypeEntity(doc);
			var roomVertices = GetRoomVertices(layEntiTypeEntity);
			var pBlockCountInRooms = CountPBlockInRooms(layEntiTypeEntity, roomVertices);
			return pBlockCountInRooms;
		}
		public  Dictionary<DGWViewModel, List<LwPolyline.Vertex>> GetRoomVertices(Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity)
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

		private  Dictionary<DGWViewModel, List<LwPolyline.Vertex>> ExtractRoomCuirtis(List<LwPolyline> polygons, IEnumerable<MText> labels, FloorTypes floorType)
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

		public  Dictionary<string, Dictionary<string, int>> CountPBlockInRooms(
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

		public bool IsPointInPolyline(XYZ point, LwPolyline polyline)
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
		public  int EnterInRoomIndexes(List<List<LwPolyline.Vertex>> vertexs, CSMath.XYZ point)
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

		public Dictionary<string, List<Line>> GetPolylinesForItem(CadDocument doc)
		{
			var layouts = GetlayEntiTypeEntity(doc);
			var roomVertices = ACadSharp.Examples.Program.GetRoomVertices(layouts);
			var circLayout = layouts["E-LUM-CIRC"];
			var lines = new List<Line>();
			foreach (var arc in circLayout[ObjectType.ARC])
			{
				lines.Add(ArcToLine(arc as Arc));
			}

			return null;
		}

		public List<string> GetBlocksForLines(List<Line> lines,
			Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity)
		{
			var result = new List<string>();

			if (!layEntiTypeEntity.ContainsKey("P-BLOCK"))
			{
				throw new KeyNotFoundException("The given key 'P-BLOCK' was not present in the dictionary.");
			}


			var pBlocks = layEntiTypeEntity["P-BLOCK"].First().Value.OfType<MText>().ToList();

			foreach(var line in lines)
			{
				var item = pBlocks.FirstOrDefault(b =>
				CompareToPointsWithStep(b.InsertPoint, line.StartPoint, 700)
				|| CompareToPointsWithStep(b.InsertPoint, line.EndPoint, 700));
				if (item != null)
				{
					result.Add(ExtractLastValue(item.Value));
				}
				else
				{
					var inserPoint=pBlocks.Select(x=>x.InsertPoint).OrderBy(p=>p.X).ToList();
					 
				}
			}

			return result;
		}

		public List<List<Line>> GetLinesListsFromArcList(IEnumerable<Arc> arcList)
		{
			const double SPACE_BETWEEN_LINES = 0.05;

			var result = new List<List<Line>>();
			var lines = arcList.Select(ArcToLine).ToList();

			for (int i = 0; i < lines.Count; i++)
			{
				var mainLine = lines[i];
				var linesForMain = new List<Line>();

				if (!IsLineInAnyGroup(result, mainLine))
				{
					linesForMain.Add(mainLine);

					for (int j = 0; j < lines.Count; j++)
					{
						var secondLine = lines[j];

						if (AreLinesClose(mainLine, secondLine, SPACE_BETWEEN_LINES) && !linesForMain.Contains(secondLine))
						{
							if (!IsLineInAnyGroup(result, secondLine))
							{
								linesForMain.Add(secondLine);
								mainLine = secondLine;
								j = -1; // reset inner loop to re-check all lines
							}
						}
					}

					if (linesForMain.Count > 0)
					{
						result.Add(linesForMain);
					}
				}
			}

			return result;
		}

		private bool AreLinesClose(Line line1, Line line2, double threshold)
		{
			return (CompareToPointsWithStep(line1.EndPoint, line2.EndPoint, threshold) && !line1.Equals(line2)) ||
				   (CompareToPointsWithStep(line1.StartPoint, line2.StartPoint, threshold) && !line1.Equals(line2)) ||
				   CompareToPointsWithStep(line1.EndPoint, line2.StartPoint, threshold) ||
				   CompareToPointsWithStep(line1.StartPoint, line2.EndPoint, threshold);
		}

		private bool IsLineInAnyGroup(List<List<Line>> groups, Line line)
		{
			return groups.Any(group => group.Contains(line));
		}


		private static bool CompareToPointsWithStep(XYZ point1, XYZ point2, double allowedSpace )
		{
			var result = false;
			result = (point2.X - allowedSpace < point1.X) && (point1.X < point2.X + allowedSpace);
			if(result )
				return (point2.Y - allowedSpace < point1.Y) && (point1.Y < point2.Y + allowedSpace);
			return result;

		}

		public Line ArcToLine(Arc arc)
		{
			XYZ startPoint = new XYZ();
			startPoint.X = arc.Center.X + arc.Radius * Math.Cos(arc.StartAngle);
			startPoint.Y = arc.Center.Y + arc.Radius * (Math.Sin(arc.StartAngle));

			XYZ endPoint = new XYZ();
			endPoint.X = arc.Center.X + arc.Radius * Math.Cos(arc.EndAngle);
			endPoint.Y = arc.Center.Y + arc.Radius * (Math.Sin(arc.EndAngle));
			return new Line(startPoint, endPoint);
		}





		public Dictionary<string, Dictionary<ObjectType, List<Entity>>> GetlayEntiTypeEntity(CadDocument doc)
		{
			var layEntiTypeEntity = new Dictionary<string, Dictionary<ObjectType, List<Entity>>>();

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


			}

			return layEntiTypeEntity;
		}
	}
}