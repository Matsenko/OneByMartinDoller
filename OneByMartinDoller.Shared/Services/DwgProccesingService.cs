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
			var roomVertices = ACadSharp.Examples.Program.GetRoomVertices(layEntiTypeEntity);
			var pBlockCountInRooms = ACadSharp.Examples.Program.CountPBlockInRooms(layEntiTypeEntity, roomVertices);
			return pBlockCountInRooms;
		}

		public List<DGWViewModel> ParseDGW(CadDocument doc)
		{ 
			var layouts = GetlayEntiTypeEntity(doc);
			var circLayout = layouts["E-LUM-CIRC"];
			var rectangles = circLayout[ObjectType.LWPOLYLINE]
				.Select(x => x as LwPolyline)
				.ToList();

			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();

			//преобразовуем arc в линии
			var lines = GetLinesListsFromsArcList(arcList);

			//ключ это квадратик, значения это линии 
			var squarLines = GetCuirtisWithRelations(lines, rectangles);

			//Квадратики заполненные  
			var cuirtises = FillCuirc(squarLines.Keys.ToList(), layouts);
			var rooms = ACadSharp.Examples.Program.GetRoomVertices(layouts);

			rooms = rooms
				.OrderBy(l => CalculateArea(l.Value))
				.ToDictionary(entry => entry.Key, entry => entry.Value);

			foreach (var item in cuirtises)
			{
				var linesForSquar = squarLines[item.Key];
				var blocks = GetBlocksForLines(linesForSquar, layouts);

				if (item.Value.CuirtsItems == null)
				{
					item.Value.CuirtsItems = new Dictionary<string, int>();
				}

				foreach (var room in rooms)
				{
					var roomName = room.Key.RoomName;
					var vertices = room.Value;

					if (ACadSharp.Examples.Program.IsPointInPolyline(linesForSquar[0].StartPoint, new LwPolyline { Vertices = vertices })
						|| ACadSharp.Examples.Program.IsPointInPolyline(linesForSquar[0].EndPoint, new LwPolyline { Vertices = vertices }))
					{
						if (room.Key.Circuits == null)
						{
							room.Key.Circuits = new List<Circuit>();
						}
						room.Key.Circuits.Add(item.Value);
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
			if (vertices.Count != 4)
			{
				throw new ArgumentException("Exactly 4 points are required.");
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
			var endLine = layEntiTypeEntity["E-LUM-GFIT"]
				.First()
				.Value
				.OfType<Insert>() 
				.ToList();
			var endLine1 = layEntiTypeEntity["E-LUM-FLMP"]
				.First()
				.Value
				.OfType<Insert>()
				.ToList();
			endLine.AddRange(endLine1); 
			foreach (var line in lines)
			{
				var item = endLine.FirstOrDefault(b =>
			CompareToPointsWithStep(b.InsertPoint, line.StartPoint, 20)
			|| CompareToPointsWithStep(b.InsertPoint, line.EndPoint, 20));
				if (item != null)
				{
					var name = ExtractLastValue(item.Block.Name);
					result.Add(name);
				}
				else
				{
					var light = endLine1.FirstOrDefault(b =>
			CompareToPointsWithStep(b.InsertPoint, line.StartPoint, 100)
			|| CompareToPointsWithStep(b.InsertPoint, line.EndPoint, 100));
					if (light != null)
					{
						//сейчас это если про свет.
						var item2 = pBlocks.FirstOrDefault(b =>
						CompareToPointsWithStep(b.InsertPoint, light.InsertPoint, 200)
						|| CompareToPointsWithStep(b.InsertPoint, light.InsertPoint, 200));
						if (item != null)
						{
							result.Add(ExtractLastValue(item2.Value));
						}

						 
					}
					
				}

				//var item = pBlocks.FirstOrDefault(b =>
				//CompareToPointsWithStep(b.InsertPoint, line.StartPoint, 20)
				//|| CompareToPointsWithStep(b.InsertPoint, line.EndPoint, 20));
				//if (item != null)
				//{
				//	result.Add(ExtractLastValue(item.Value));
				//}
				//else
				//{
				//	var inserPoint=pBlocks.Select(x=>x.InsertPoint).OrderBy(p=>p.X).ToList();
				//}
			}

			return result;
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
						var b1 = ACadSharp.Examples.Program.IsPointInPolyline(l.StartPoint, rect,50);
						var b2 = ACadSharp.Examples.Program.IsPointInPolyline(l.EndPoint, rect,50);
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

			foreach(var circ in circRectangle)
			{
				var circBlcocksItems = new List<MText>();
				foreach (var block in pBlocks)
				{
					if(ACadSharp.Examples.Program.IsPointInPolyline(block.InsertPoint,circ))
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
	}
}