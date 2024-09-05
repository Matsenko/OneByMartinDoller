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
using System.Drawing;

using ACadSharp.Blocks;
using OneByMartinDoller.Shared.Model;
using System.Reflection;



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
							startBracketIndex = input.IndexOf('{');
							closingBracketIndex = input.IndexOf('}');
							semicolonIndex = input.IndexOf(';');
							if (startBracketIndex < 0
								|| closingBracketIndex < 0
								|| semicolonIndex < 0)
							{
								result = input;
							}
							else
							{ 
								secondChar = input.Substring(0, startBracketIndex);
								result = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1).Trim();
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
			if (layEntiTypeEntity.ContainsKey("A-LABEL-LGF"))
			{
				var groundFloor = layEntiTypeEntity["A-LABEL-LGF"].Values.SelectMany(e => e.OfType<MText>());
				foreach (var item in ExtractRoomCuirtis(polygons, groundFloor, FloorTypes.GroundFloor))
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


		public List<DGWViewModel> ParseDGW(CadDocument doc)
		{ 
			var layouts = GetlayEntiTypeEntity(doc);
			var circLayout = layouts.ContainsKey("E-LUM-CIRC")
				?layouts["E-LUM-CIRC"]
				: new Dictionary<ObjectType, List<Entity>>();

			var rectangles = circLayout.ContainsKey(ObjectType.LWPOLYLINE)
				? circLayout[ObjectType.LWPOLYLINE]
				.Select(x => x as LwPolyline).ToList()
				: new List<LwPolyline?>();

			var arcList = circLayout.ContainsKey(ObjectType.ARC)
				? circLayout[ObjectType.ARC].Select(x => x as Arc).ToList()
				: new List<Arc>();
			if (!arcList.Any())
				throw new FormatException("not valid file format, please check all requiment layouts");
			//преобразовуем arc в линии, те которые идут от прямоугольников с буквами
			var lines = GetLinesListsFromsArcList(arcList);

			//ключ это квадратик, значения это линии 
			var squarLines = GetCuirtisWithRelations(lines, rectangles);

			//Квадратики заполненные  
			var cuirtises = FillCuirc(squarLines.Keys.ToList(), layouts);
			var rooms = GetRoomVertices(layouts);

			rooms = rooms
				.OrderBy(l => CalculateArea(l.Value))
				.ToDictionary(entry => entry.Key, entry => entry.Value);

			foreach (var item in cuirtises)
			{
				var linesForSquar = squarLines[item.Key];
				var blocks = GetBlocksForLines(linesForSquar, layouts);

				if (item.Value.CuirtsItems == null)
				{
					item.Value.CuirtsItems = new Dictionary<BlockItem, int>();
				}

				foreach (var room in rooms)
				{
					var roomName = room.Key.RoomName;
					var vertices = room.Value;
					room.Key.ZoneName = GetZoneName(layouts, vertices);
					if (IsPointInPolyline(linesForSquar[0].StartPoint, new LwPolyline { Vertices = vertices })
						|| IsPointInPolyline(linesForSquar[0].EndPoint, new LwPolyline { Vertices = vertices }))
					{
						if (room.Key.Circuits == null)
						{
							room.Key.Circuits = new List<Circuit>();
						}
						room.Key.Circuits.Add(item.Value);
						break;	
					}
				}

				foreach (var block in blocks)
				{
					if (!item.Value.CuirtsItems.ContainsKey(block))
						item.Value.CuirtsItems.Add(block, 0);
					item.Value.CuirtsItems[block]++;
				}

			}

			return rooms.Keys.ToList();
		}

		public static double CalculateArea(List<LwPolyline.Vertex> vertices)
		{
			if (vertices.Count < 3)
			{
				throw new ArgumentException("At least 3 points are required to form a polygon.");
			}

			double area = 0;
			for (int i = 0; i < vertices.Count; i++)
			{
				int nextIndex = (i + 1) % vertices.Count;
				area += vertices[i].Location.X * vertices[nextIndex].Location.Y;
				area -= vertices[i].Location.Y * vertices[nextIndex].Location.X;
			}

			area = Math.Abs(area) / 2.0;
			return area;
		}


		public Dictionary<string, List<Line>> GetPolylinesForItem(CadDocument doc)
		{
			var layouts = GetlayEntiTypeEntity(doc);
			var roomVertices = GetRoomVertices(layouts);
			var circLayout = layouts["E-LUM-CIRC"];
			var lines = new List<Line>();
			foreach (var arc in circLayout[ObjectType.ARC])
			{
				lines.Add(ArcToLine(arc as Arc));
			}

			return null;
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
			XYZ xYZ4 = new XYZ(point.X, point.Y + step, 0);

			XYZ xYZ5 = new XYZ(point.X-step, point.Y+step, 0);
			XYZ xYZ6 = new XYZ(point.X+step, point.Y - step, 0);


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

			var xAdded1 = IsPointInPolyline(xYZ5, polyline);
			if (xAdded1) return xAdded1;

			var yAdded2 = IsPointInPolyline(xYZ6, polyline);
			if (yAdded2) return yAdded2;

			return false;
		}

		public static bool IsPointInPolyline(XYZ point, LwPolyline polyline)
		{
			var vertices = polyline.Vertices;
			bool isInside = false;

		
			for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
			{
				var xi = vertices[i].Location.X;
				var yi = vertices[i].Location.Y;
				var xj = vertices[j].Location.X;
				var yj = vertices[j].Location.Y;

			
				if ((yi > point.Y) != (yj > point.Y) &&
					point.X < (xj - xi) * (point.Y - yi) / (yj - yi) + xi)
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

		public List<BlockItem> GetBlocksForLines(List<Line> lines,
			Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity)
		{
			var result = new List<BlockItem>();

			if (!layEntiTypeEntity.ContainsKey("P-BLOCK"))
			{
				throw new KeyNotFoundException("The given key 'P-BLOCK' was not present in the dictionary.");
			}


			var pBlocks = layEntiTypeEntity["P-BLOCK"].First().Value.OfType<MText>().ToList();
			if (layEntiTypeEntity.ContainsKey("E-LUM-CIRC"))
			{
				var it2 = layEntiTypeEntity["E-LUM-CIRC"][ObjectType.MTEXT].OfType<MText>().ToList();
				pBlocks.AddRange(it2);
			}
			List<Insert> endLine;
			if (layEntiTypeEntity.ContainsKey("E-LUM-GFIT"))
			{
				endLine = layEntiTypeEntity["E-LUM-GFIT"]
				.First()
				.Value
				.OfType<Insert>()
				.ToList();
			}
			else
			{
				endLine= new List<Insert>();
			}

			List<Insert> ledItems;
			if (layEntiTypeEntity.ContainsKey("E-LUM-FLMP"))
			{
				ledItems = layEntiTypeEntity["E-LUM-FLMP"]
					.First()
					.Value
					.OfType<Insert>()
					.ToList();
			}
			else
			{
				ledItems= new List<Insert>();
			}

			//endLine.AddRange(endLine1); 
			foreach (var line in lines)
			{
				var item = endLine.FirstOrDefault(b =>
			CompareToPointsWithStep(b.InsertPoint, line.StartPoint, 50)
			|| CompareToPointsWithStep(b.InsertPoint, line.EndPoint, 50));
				if (item != null)
				{
					var name = ExtractLastValue(item.Block.Name);
					result.Add(new BlockItem { MainBlock=name, SubBlock=string.Empty});
				}
				else
				{
					var mainBlockName=pBlocks.OrderBy(p=>GetDistance(line.StartPoint,p.InsertPoint)).FirstOrDefault();
					if(mainBlockName != null)
					{
						var ledName= ledItems.FirstOrDefault(b =>
			CompareToPointsWithStep(b.InsertPoint, line.StartPoint, 50)
			|| CompareToPointsWithStep(b.InsertPoint, line.EndPoint, 50));
						if(mainBlockName!=null)
						{
							var mainBlock = ExtractLastValue(mainBlockName.Value);
							var ledBlock = ledName==null?string.Empty:ledName.Block.Name;
							result.Add(new BlockItem { MainBlock=mainBlock, SubBlock=ledBlock});
						}
					}	 
				}
				 
			}

			return result;
		}

		static double GetDistance(XYZ point1, XYZ point2)
		{
			return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
		}


		public bool CheckPointConnectToLed(Line line,
			Dictionary<string, Dictionary<ObjectType, List<Entity>>> layEntiTypeEntity)
		{

			if (!layEntiTypeEntity.ContainsKey("E-LUM-LED"))
			{
				throw new KeyNotFoundException("The given key 'P-BLOCK' was not present in the dictionary.");
			}


			var leds = layEntiTypeEntity["E-LUM-LED"][ObjectType.LWPOLYLINE].OfType<LwPolyline>().ToList(); 

			var item = leds.FirstOrDefault(b =>
			CompareToPointsWithStep(line.StartPoint, b.Vertices[0].Location, 500)
			|| CompareToPointsWithStep(line.EndPoint, b.Vertices[0].Location, 500));


			if (item != null)
			{
				return true;
			} 

			return false;
		}

		public List<List<Line>> GetLinesListsFromsArcList(IEnumerable<Arc> arcList)
		{
			const double SPACE_BETWEEN_LINES = 0.05;
			
			var result =new List<List<Line>>();
			var lines = arcList.Select(x => ArcToLine(x)).ToList();

			//move foward
			int i = 0;

			while (i < lines.Count)
			{
				var mainLine = lines[i];
				int j = 0;
				var linesForMain = new List<Line>();
				
				if (!result.Any(x => x.Contains(mainLine)))
					linesForMain.Add(mainLine);

				while (j < lines.Count)
				{
					var secondLine = lines[j];
					if (
						((CompareToPointsWithStep(mainLine.EndPoint, secondLine.EndPoint, SPACE_BETWEEN_LINES)
						&& !mainLine.Equals(secondLine))
						|| (CompareToPointsWithStep(mainLine.StartPoint, secondLine.StartPoint, SPACE_BETWEEN_LINES)
						&& !mainLine.Equals(secondLine))
						|| CompareToPointsWithStep(mainLine.EndPoint, secondLine.StartPoint, SPACE_BETWEEN_LINES)
						|| CompareToPointsWithStep(mainLine.StartPoint, secondLine.EndPoint, SPACE_BETWEEN_LINES))
						&& !linesForMain.Contains(secondLine))
					{
						if (!result.Any(x => x.Contains(secondLine)))
						{
							linesForMain.Add(secondLine);
							mainLine = secondLine;
							j = 0;
						}
					}
					j++;
				}
				if(linesForMain.Count > 0)
				{
					result.Add(linesForMain);
				}
				i++;
			}

			var itemCount=result.Sum(x=>x.Count);
			var temp=result.OrderBy(x=>x.Count);
			return result;

		}

		private static bool CompareToPointsWithStep(XYZ point1, XYZ point2, double allowedSpace )
		{
			var result = false;
			result = (point2.X - allowedSpace < point1.X) && (point1.X < point2.X + allowedSpace);
			if(result )
				return (point2.Y - allowedSpace < point1.Y) && (point1.Y < point2.Y + allowedSpace);
			return result;

		}

		private static bool CompareToPointsWithStep(XYZ point1, XY point2, double allowedSpace)
		{
			return CompareToPointsWithStep(point1, new XYZ(point2.X, point2.Y, 0), allowedSpace);
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="lines"> Grouped lines by polilines </param>
		/// <param name="rectangles"></param>
		/// <exception cref="NotImplementedException"></exception>
		public Dictionary<LwPolyline, List<Line>> GetCuirtisWithRelations(List<List<Line>> lines, List<LwPolyline> rectangles)
		{
			Dictionary<LwPolyline, List<Line>> result = new Dictionary<LwPolyline, List<Line>>();

			foreach(LwPolyline rect in rectangles)
			{ 
				foreach(var line in lines)
				{
					foreach (var l in line)
					{
						var b1 =IsPointInPolyline(l.StartPoint, rect,100);
						var b2 = IsPointInPolyline(l.EndPoint, rect,100);
						if (b1 || b2)
						{
							result.Add(rect, line);
						}

					}
				}
			}

			return result;
		}

		public Dictionary<LwPolyline, Circuit> FillCuirc(List<LwPolyline> circRectangle, Dictionary<string, Dictionary<ObjectType, List<Entity>>> layouts)
		{
			var result = new Dictionary<LwPolyline, Circuit>();

			if (!layouts.ContainsKey("P-BLOCK"))
			{
				throw new KeyNotFoundException("The given key 'P-BLOCK' was not present in the dictionary.");
			} 
			var pBlocks = layouts["P-BLOCK"][ObjectType.MTEXT].OfType<MText>().ToList();
			if (layouts.ContainsKey("E-LUM-CIRC"))
			{
				var it2 = layouts["E-LUM-CIRC"][ObjectType.MTEXT].OfType<MText>().ToList();
				pBlocks.AddRange(it2);
			}
			foreach (var circ in circRectangle)
			{
				var circBlcocksItems = new List<MText>();
				foreach (var block in pBlocks)
				{
					if(IsPointInPolyline(block.InsertPoint,circ,30))
					{ 
						circBlcocksItems.Add(block);
					}
				}
				
				if(circBlcocksItems.Count > 1)
				{
					var t = circBlcocksItems
						.OrderByDescending(x => x.InsertPoint.X)
						.Select(t => ExtractLastValue(t.Value));

					var item = new Circuit()
					{
						Name = t.FirstOrDefault(),
						Cuirts = string.Join('+', t.Skip(1))
					};
					result.Add(circ, item);	
				}
			}



			return result;
		}

		public string GetZoneName(Dictionary<string, Dictionary<ObjectType, List<Entity>>> layouts, List<LwPolyline.Vertex> vertices)
		{
			var b = layouts.Keys.ToList();
			var bint = layouts.ContainsKey("B-INT") ? layouts["B-INT"] : null;
			var bBoh = layouts.ContainsKey("B-BOH")? layouts["B-BOH"] : null;
			var bFoh= layouts.ContainsKey("B-FOH")? layouts["B-FOH"] : null;

			var bIntPol= bint!=null
							? bint.Values.SelectMany(e => e.OfType<LwPolyline>()).ToList()
							: new List<LwPolyline>();
			var bBohPol = bBoh != null
							? bBoh.Values.SelectMany(e => e.OfType<LwPolyline>()).ToList()
							: new List<LwPolyline>();
			var bFohPol = bFoh != null
							? bFoh.Values.SelectMany(e => e.OfType<LwPolyline>()).ToList()
							: new List<LwPolyline>();

			if (IsRoomInZone(bIntPol, vertices))
				return "INT";
			if (IsRoomInZone(bBohPol, vertices))
				return "BOH";
			if (IsRoomInZone(bFohPol, vertices))
				return "FOH";
			 
			return string.Empty; 
		}

		private bool IsRoomInZone(List<LwPolyline> zone,List<LwPolyline.Vertex> room)
		{
			foreach (var z in zone)
			{
				int enterTime = 0;
				foreach (var r in room)
				{
					if (IsPointInPolyline(r.Location, z, 100))
					{
						enterTime++;
					}
					if (enterTime == 4)
						return true;
				}
			}
			return false;
		}

		public bool SquarInSquar(LwPolyline mainSquar, LwPolyline secondSquar)
		{


			// Получаем все вершины главной полилинии
			var mainPoints = mainSquar.Vertices.Select(x => new XY(x.Location.X,x.Location.Y<-2740?x.Location.Y-100:x.Location.Y)).ToList(); 
			
			// Получаем все вершины дочерней полилинии
			var childPoints = secondSquar.Vertices.Select(x => x.Location);

			// Проверяем, все ли вершины дочерней полилинии находятся внутри главной полилинии
			foreach (var childPoint in childPoints)
			{
				if (!IsPointInPolyline(mainPoints, childPoint))
				{
					return false; // Если хоть одна точка не внутри, возвращаем false
				}
			}

			return true; // Все точки дочерней полилинии внутри
		}
		 

		private static bool IsPointInPolyline(List<XY> polylinePoints, XY point)
		{
			int i, j = polylinePoints.Count - 1;
			bool inside = false;

			for (i = 0; i < polylinePoints.Count; i++)
			{
				if (((polylinePoints[i].Y > point.Y) != (polylinePoints[j].Y > point.Y)) &&
					(point.X < (polylinePoints[j].X - polylinePoints[i].X) 
					* (point.Y - polylinePoints[i].Y) / (polylinePoints[j].Y - polylinePoints[i].Y) 
					+ polylinePoints[i].X))
				{
					inside = !inside;
				}
				j = i;
			}

			return inside;
		}
	}
}