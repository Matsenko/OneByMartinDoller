//using ACadSharp.Entities;
//using ACadSharp.IO;
//using ACadSharp.Tables;
//using ACadSharp.Tables.Collections;
//using ACadSharp;
//using OneByMartinDoller.Shared.Services;
//using System.Net;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OneByMartinDoller.Shared.Services.IServices;
//using OneByMartinDoller.Shared.Model;
//using ACadSharp.Examples.Model;

//namespace OneByMartinDoller.Tests
//{
	
//	[TestClass]
//	public class DWGProcessingTest
//	{
//		private readonly DwgProccesingService _service = new DwgProccesingService();
//		const string _file = "C:\\Users\\belbo\\Downloads\\Showroom Drafting (5).dwg";

//		[TestMethod]
//		public void ArcToLine_shouldReturn14LinesWhoHasStartOrEndPointWhoNotExsistInRoom()
//		{
//			var layouts = _service.GetlayEntiTypeEntity(GetDocument());
//			var roomVertices = ACadSharp.Examples.Program.GetRoomVertices(layouts);
//			var circLayout = layouts["E-LUM-CIRC"];
//			var lines = new List<Line>();
//			foreach (var arc in circLayout[ObjectType.ARC])
//			{
//				lines.Add(_service.ArcToLine(arc as Arc));
//			}

//			var lineOutOfShema=new List<Line>();

//			foreach (var line in lines)
//			{
//				var existInRoom = false;
//				foreach(var room in roomVertices)
//				{
//					var poliLine=new LwPolyline { Vertices=room.Value };

//					if (ACadSharp.Examples.Program.IsPointInPolyline(line.StartPoint, poliLine) &&
//										ACadSharp.Examples.Program.IsPointInPolyline(line.EndPoint, poliLine))
//					{
//						existInRoom = true;
//						break;
//					}
//				}
//				if(!existInRoom)
//					lineOutOfShema.Add(line);
//			}

//			Assert.AreEqual(14, lineOutOfShema.Count); 

//		}

//		[TestMethod]
//		public void GetVerticesFromArc_15VerticesConnected()
//		{
//			var doc = GetDocument();
//			var layouts = _service.GetlayEntiTypeEntity(doc); 
//			var circLayout = layouts["E-LUM-CIRC"];
//			var lines = new List<Line>();

//			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
//			var result=_service.GetLinesListsFromsArcList(arcList);

//			Assert.AreEqual(15, result.Count);

//		}

//		[TestMethod]
//		public void GetBlocksForLines_GivesLines_PBlocksValueForLines()
//		{
//			var doc = GetDocument();
//			var layouts = _service.GetlayEntiTypeEntity(doc);
//			var circLayout = layouts["E-LUM-CIRC"]; 

//			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
//			var lines = _service.GetLinesListsFromsArcList(arcList);
//			var tempR = new Dictionary<List<Line>, List<BlockItem>>();
//			foreach(var line in lines)
//			{
//				var r=_service.GetBlocksForLines(line, layouts);
//				if(r.Count > 0)
//					tempR.Add(line,r);
//			}

//			Assert.AreEqual(15, tempR.Count);
//		}


//		[TestMethod]
//		public void CheckPointConnectToLed()
//		{
//			var doc = GetDocument();
//			var layouts = _service.GetlayEntiTypeEntity(doc);
//			var circLayout = layouts["E-LUM-CIRC"];

//			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
//			var lines = _service.GetLinesListsFromsArcList(arcList);
//			Dictionary<List<Line>, List<bool>> tempR = new Dictionary<List<Line>, List<bool>>();


//			foreach (var line in lines)
//			{
//				var ledIs=new List<bool>();
//				foreach (var line2 in line)
//				{
//					var r = _service.CheckPointConnectToLed(line2, layouts);
//					ledIs.Add(r);
//				}
//				tempR.Add(line, ledIs);
				 
//			}

//			Assert.AreEqual(4, tempR.Where(x=>x.Value.Any(v=>v)).Count());
//		}

//		[TestMethod]
//		public void GetCuirtisWithRelations_ProvideLines_GetCuirtiesWithRelations()
//		{
//			var doc = GetDocument();
//			var layouts = _service.GetlayEntiTypeEntity(doc);
//			var circLayout = layouts["E-LUM-CIRC"];

//			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
//			var lines = _service.GetLinesListsFromsArcList(arcList);

//			var rectangles = circLayout[ObjectType.LWPOLYLINE].Select(x=>x as LwPolyline).ToList();

//			var result=_service.GetCuirtisWithRelations(lines, rectangles);

//			Assert.AreEqual(15, result.Count);
//		}

//		[TestMethod]
//		public void FillCuirc_ProvideCuirties_GetCuirtisWithCuirt()
//		{
//			var doc = GetDocument();
//			var layouts = _service.GetlayEntiTypeEntity(doc);
//			var circLayout = layouts["E-LUM-CIRC"];
//			var rectangles = circLayout[ObjectType.LWPOLYLINE].Select(x => x as LwPolyline).ToList();
			
//			var result=_service.FillCuirc(rectangles, layouts);

//			Assert.AreEqual(15, result.Count);
//		}

//		[TestMethod]
//		public void ParseDocument()
//		{
//			var result=_service.ParseDGW(GetDocument());
			
//			var restroom = result.FirstOrDefault(x => x.RoomName.ToLower().Equals("restroom"));
//			var kitchenette = result.FirstOrDefault(x => x.RoomName.ToLower().Equals("kitchenette"));
//			var zoomRoom = result.FirstOrDefault(x => x.RoomName.ToLower().Equals("zoom room"));
//			var exterior = result.FirstOrDefault(x => x.RoomName.ToLower().Equals("exterior"));

//			var boardroom = result.FirstOrDefault(x => x.RoomName.ToLower().Equals("boardroom"));
//			var exhibitionRoom = result.FirstOrDefault(x => x.RoomName.ToLower().Equals("exhibition room"));


//			var entrance = result.FirstOrDefault(x => x.RoomName.ToLower().Equals("entrance"));

//			#region restroom

//			Assert.AreEqual(1, restroom.Circuits.Count());
//			Assert.AreEqual("AX1", restroom.Circuits[0].Name);
//			Assert.AreEqual("GF.A1", restroom.Circuits[0].Cuirts.ToUpper());
//			Assert.AreEqual(1, restroom.Circuits[0].CuirtsItems.Count);
//			Assert.IsTrue( restroom.Circuits[0].CuirtsItems.ContainsKey("AX1"));
//			Assert.AreEqual(1, restroom.Circuits[0].CuirtsItems["AX1"]);

//			#endregion

//			#region kitchenette

//			Assert.AreEqual(1, kitchenette.Circuits.Count());
//			Assert.AreEqual("AX1", kitchenette.Circuits[0].Name);
//			Assert.AreEqual("GF.A2", kitchenette.Circuits[0].Cuirts.ToUpper());
//			Assert.AreEqual(1, kitchenette.Circuits[0].CuirtsItems.Count);
//			Assert.IsTrue(kitchenette.Circuits[0].CuirtsItems.ContainsKey("AX1"));
//			Assert.AreEqual(1, kitchenette.Circuits[0].CuirtsItems["AX1"]);

//			#endregion

//			#region zoomRoom

//			Assert.AreEqual(2, zoomRoom.Circuits.Count());
//			Assert.IsTrue(zoomRoom.Circuits.Any(c=>c.Name.Equals("A1")));
//			Assert.IsTrue(zoomRoom.Circuits.Any(c=>c.Cuirts.ToUpper()== "GF.A3"));
//			Assert.IsTrue(zoomRoom.Circuits.Any(c=>c.Cuirts.ToUpper()== "GF.A4"));
//			Assert.AreEqual(3, zoomRoom.Circuits.Sum(c=>c.CuirtsItems.Sum(x=>x.Value)));
//			Assert.IsTrue(zoomRoom.Circuits.Any(c=>c.CuirtsItems.ContainsKey("A1") && c.CuirtsItems["A1"]==2));
//			Assert.IsTrue(zoomRoom.Circuits.Any(c=>c.CuirtsItems.ContainsKey("LJ") && c.CuirtsItems["LJ"]==1));
			 

//			#endregion

//			#region exterior

//			Assert.AreEqual(4, exterior.Circuits.Count());

//			Assert.IsTrue(exterior.Circuits.Any(c => c.Cuirts.ToUpper() == "EX.A4"));
//			Assert.IsTrue(exterior.Circuits.Any(c => c.Cuirts.ToUpper() == "EX.A3"));
//			Assert.IsTrue(exterior.Circuits.Any(c => c.Cuirts.ToUpper() == "EX.A2"));
//			Assert.IsTrue(exterior.Circuits.Any(c => c.Cuirts.ToUpper() == "EX.A1"));

//			Assert.AreEqual(14, exterior.Circuits.Sum(c => c.CuirtsItems.Sum(x=>x.Value)));

//			Assert.IsTrue(exterior.Circuits.Any(c => c.CuirtsItems.ContainsKey("GB1") && c.CuirtsItems["GB1"] == 6));
//			Assert.IsTrue(exterior.Circuits.Any(c => c.CuirtsItems.ContainsKey("BX1") && c.CuirtsItems["BX1"] == 3));
//			Assert.IsTrue(exterior.Circuits.Any(c => c.CuirtsItems.ContainsKey("FX1") && c.CuirtsItems["FX1"] == 4));
//			Assert.IsTrue(exterior.Circuits.Any(c => c.CuirtsItems.ContainsKey("LCX") && c.CuirtsItems["LCX"] == 1)); 

//			#endregion

//			#region boardroom

//			Assert.AreEqual(2, boardroom.Circuits.Count());
//			Assert.IsTrue(boardroom.Circuits.Any(c => c.Name.Equals("A1+LJ")));
//			Assert.IsTrue(boardroom.Circuits.Any(c => c.Cuirts.ToUpper() == "FF.A2"));
//			Assert.IsTrue(boardroom.Circuits.Any(c => c.Cuirts.ToUpper() == "FF.A1"));
//			Assert.AreEqual(8, boardroom.Circuits.Sum(c => c.CuirtsItems.Sum(x => x.Value)));
//			Assert.IsTrue(boardroom.Circuits.Any(c => c.CuirtsItems.ContainsKey("LJ") && c.CuirtsItems["LJ"] == 1));
//			Assert.IsTrue(boardroom.Circuits.Any(c => c.CuirtsItems.ContainsKey("A1") && c.CuirtsItems["A1"] == 5));
//			Assert.IsTrue(boardroom.Circuits.Any(c => c.CuirtsItems.ContainsKey("W1") && c.CuirtsItems["W1"] == 2)); 

//			#endregion

//			#region exhibitionRoom

//			Assert.AreEqual(3, exhibitionRoom.Circuits.Count());
//			Assert.IsTrue(exhibitionRoom.Circuits.Any(c => c.Name.Equals("A1")));
//			Assert.IsTrue(exhibitionRoom.Circuits.Any(c => c.Cuirts.ToUpper() == "GF.B1"));
//			Assert.IsTrue(exhibitionRoom.Circuits.Any(c => c.Cuirts.ToUpper() == "GF.B2"));
//			Assert.IsTrue(exhibitionRoom.Circuits.Any(c => c.Cuirts.ToUpper() == "GF.B3"));
//			Assert.AreEqual(11, exhibitionRoom.Circuits.Sum(c => c.CuirtsItems.Sum(x => x.Value)));
//			Assert.IsTrue(exhibitionRoom.Circuits.Any(c => c.CuirtsItems.ContainsKey("A1") && c.CuirtsItems["A1"] == 7));
//			Assert.IsTrue(exhibitionRoom.Circuits.Any(c => c.CuirtsItems.ContainsKey("LC") && c.CuirtsItems["LC"] == 2));
//			Assert.IsTrue(exhibitionRoom.Circuits.Any(c => c.CuirtsItems.ContainsKey("B1") && c.CuirtsItems["B1"] == 2)); 

//			#endregion

//			#region entrance

//			Assert.AreEqual(2, entrance.Circuits.Count());
//			Assert.IsTrue(entrance.Circuits.Any(c => c.Name.Equals("A1")));
//			Assert.IsTrue(entrance.Circuits.Any(c => c.Cuirts.ToUpper() == "GF.C1"));
//			Assert.IsTrue(entrance.Circuits.Any(c => c.Cuirts.ToUpper() == "GF.C2"));
//			Assert.AreEqual(4, entrance.Circuits.Sum(c => c.CuirtsItems.Sum(x => x.Value)));
//			Assert.IsTrue(entrance.Circuits.Any(c => c.CuirtsItems.ContainsKey("A1") && c.CuirtsItems["A1"] == 2));
//			Assert.IsTrue(entrance.Circuits.Any(c => c.CuirtsItems.ContainsKey("W1") && c.CuirtsItems["W1"] == 2)); 

//			#endregion
//		}

//		[TestMethod]
//		public void FinalTestForParseDGWFile()
//		{ 
//			var doc = GetDocument();
//			var layouts = _service.GetlayEntiTypeEntity(doc);
//			var circLayout = layouts["E-LUM-CIRC"];
//			var rectangles = circLayout[ObjectType.LWPOLYLINE]
//				.Select(x => x as LwPolyline)
//				.ToList();

//			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
			
//			//преобразовуем arc в линии
//			var lines = _service.GetLinesListsFromsArcList(arcList);

//			//ключ это квадратик, значения это линии 
//			var squarLines = _service.GetCuirtisWithRelations(lines, rectangles);

//			//Квадратики заполненные  
//			var cuirtises = _service.FillCuirc(squarLines.Keys.ToList(), layouts);
//			var rooms = ACadSharp.Examples.Program.GetRoomVertices(layouts);


//			foreach (var item in cuirtises)
//			{
//				var linesForSquar = squarLines[item.Key];
//				var blocks = _service.GetBlocksForLines(linesForSquar, layouts);

//				if (item.Value.CuirtsItems == null)
//				{
//					item.Value.CuirtsItems = new Dictionary<BlockItem, int>();
//				}

//				foreach (var room in rooms)
//				{
//					var roomName = room.Key.RoomName;
//					var vertices = room.Value;

//					if (ACadSharp.Examples.Program.IsPointInPolyline(linesForSquar[0].StartPoint, new LwPolyline { Vertices = vertices })
//						|| ACadSharp.Examples.Program.IsPointInPolyline(linesForSquar[0].EndPoint, new LwPolyline { Vertices = vertices }))
//					{
//						if(room.Key.Circuits == null)
//						{
//							room.Key.Circuits=new List<Circuit>();
//						}
//						room.Key.Circuits.Add(item.Value);
//					}
//				}

//				foreach (var block in blocks)
//				{

//					if(!item.Value.CuirtsItems.ContainsKey(block))
//						item.Value.CuirtsItems.Add(block, 1);
//					item.Value.CuirtsItems[block]++;
//				}
				 
//			}

			

//			////линиии с буквами
//			//Dictionary<List<Line>, List<string>> tempR = new Dictionary<List<Line>, List<string>>();
//			//foreach (var line in lines)
//			//{
//			//	var r = _service.GetBlocksForLines(line, layouts);
//			//	if (r.Count > 0)
//			//		tempR.Add(line, r);
//			//}

//			//линии с светом 
//			//Dictionary<List<Line>, List<bool>> tempR1 = new Dictionary<List<Line>, List<bool>>();
//			//foreach (var line in lines)
//			//{
//			//	var ledIs = new List<bool>();
//			//	foreach (var line2 in line)
//			//	{
//			//		var r = _service.CheckPointConnectToLed(line2, layouts);
//			//		ledIs.Add(r);
//			//	}
//			//	tempR1.Add(line, ledIs);
//			//}



//			//комнаты

//		}

//		private CadDocument GetDocument()
//		{

//			CadDocument doc;
//			using (DwgReader reader = new DwgReader(_file))
//			{
//				doc = reader.Read();
//			}
//			return doc;
//		}
//	}
//}