using ACadSharp.Entities;
using ACadSharp.IO;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using ACadSharp;
using OneByMartinDoller.Shared.Services;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneByMartinDoller.Shared.Services.IServices;

namespace OneByMartinDoller.Tests
{
	
	[TestClass]
	public class DWGProcessingTest
	{
		private readonly DwgProccesingService _service = new DwgProccesingService();
		const string _file = "C:\\Users\\belbo\\Downloads\\Showroom Drafting (4).dwg";

		[TestMethod]
		public void ArcToLine_shouldReturn14LinesWhoHasStartOrEndPointWhoNotExsistInRoom()
		{
			var layouts = _service.GetlayEntiTypeEntity(GetDocument());
			var roomVertices = ACadSharp.Examples.Program.GetRoomVertices(layouts);
			var circLayout = layouts["E-LUM-CIRC"];
			var lines = new List<Line>();
			foreach (var arc in circLayout[ObjectType.ARC])
			{
				lines.Add(_service.ArcToLine(arc as Arc));
			}

			var lineOutOfShema=new List<Line>();

			foreach (var line in lines)
			{
				var existInRoom = false;
				foreach(var room in roomVertices)
				{
					var poliLine=new LwPolyline { Vertices=room.Value };

					if (ACadSharp.Examples.Program.IsPointInPolyline(line.StartPoint, poliLine) &&
										ACadSharp.Examples.Program.IsPointInPolyline(line.EndPoint, poliLine))
					{
						existInRoom = true;
						break;
					}
				}
				if(!existInRoom)
					lineOutOfShema.Add(line);
			}

			Assert.AreEqual(14, lineOutOfShema.Count); 

		}

		[TestMethod]
		public void GetVerticesFromArc_15VerticesConnected()
		{
			var doc = GetDocument();
			var layouts = _service.GetlayEntiTypeEntity(doc); 
			var circLayout = layouts["E-LUM-CIRC"];
			var lines = new List<Line>();

			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
			var result=_service.GetLinesListsFromsArcList(arcList);

			Assert.AreEqual(15, result.Count);

		}

		[TestMethod]
		public void GetBlocksForLines_GivesLines_PBlocksValueForLines()
		{
			var doc = GetDocument();
			var layouts = _service.GetlayEntiTypeEntity(doc);
			var circLayout = layouts["E-LUM-CIRC"]; 

			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
			var lines = _service.GetLinesListsFromsArcList(arcList);
			Dictionary<List<Line>, List<string>> tempR = new Dictionary<List<Line>, List<string>>();
			foreach(var line in lines)
			{
				var r=_service.GetBlocksForLines(line, layouts);
				if(r.Count > 0)
					tempR.Add(line,r);
			}

			Assert.AreEqual(15, tempR.Count);
		}


		[TestMethod]
		public void CheckPointConnectToLed()
		{
			var doc = GetDocument();
			var layouts = _service.GetlayEntiTypeEntity(doc);
			var circLayout = layouts["E-LUM-CIRC"];

			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
			var lines = _service.GetLinesListsFromsArcList(arcList);
			Dictionary<List<Line>, List<bool>> tempR = new Dictionary<List<Line>, List<bool>>();


			foreach (var line in lines)
			{
				var ledIs=new List<bool>();
				foreach (var line2 in line)
				{
					var r = _service.CheckPointConnectToLed(line2, layouts);
					ledIs.Add(r);
				}
				tempR.Add(line, ledIs);
				 
			}

			Assert.AreEqual(4, tempR.Where(x=>x.Value.Any(v=>v)).Count());
		}

		[TestMethod]
		public void GetCuirtisWithRelations_ProvideLines_GetCuirtiesWithRelations()
		{
			var doc = GetDocument();
			var layouts = _service.GetlayEntiTypeEntity(doc);
			var circLayout = layouts["E-LUM-CIRC"];

			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
			var lines = _service.GetLinesListsFromsArcList(arcList);

			var rectangles = circLayout[ObjectType.LWPOLYLINE].Select(x=>x as LwPolyline).ToList();

			var result=_service.GetCuirtisWithRelations(lines, rectangles);

			Assert.AreEqual(15, result.Count);
		}

		[TestMethod]
		public void FillCuirc_ProvideCuirties_GetCuirtisWithCuirt()
		{
			var doc = GetDocument();
			var layouts = _service.GetlayEntiTypeEntity(doc);
			var circLayout = layouts["E-LUM-CIRC"];
			var rectangles = circLayout[ObjectType.LWPOLYLINE].Select(x => x as LwPolyline).ToList();
			
			var result=_service.FillCuirc(rectangles, layouts);

			Assert.AreEqual(15, result.Count);
		}

		[TestMethod]
		public void ParseDocument()
		{

		}

		[TestMethod]
		public void FinalTestForParseDGWFile()
		{


			var doc = GetDocument();
			var layouts = _service.GetlayEntiTypeEntity(doc);
			var circLayout = layouts["E-LUM-CIRC"];
			var rectangles = circLayout[ObjectType.LWPOLYLINE]
				.Select(x => x as LwPolyline)
				.ToList();

			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
			
			//преобразовуем arc в линии
			var lines = _service.GetLinesListsFromsArcList(arcList);

			//ключ это квадратик, значения это линии 
			var squarLines = _service.GetCuirtisWithRelations(lines, rectangles);

			//Квадратики заполненные  
			var cuirtises = _service.FillCuirc(squarLines.Keys.ToList(), layouts);
			 

			
			//линиии с буквами
			Dictionary<List<Line>, List<string>> tempR = new Dictionary<List<Line>, List<string>>();
			foreach (var line in lines)
			{
				var r = _service.GetBlocksForLines(line, layouts);
				if (r.Count > 0)
					tempR.Add(line, r);
			}

			//линии с светом 
			Dictionary<List<Line>, List<bool>> tempR1 = new Dictionary<List<Line>, List<bool>>();
			foreach (var line in lines)
			{
				var ledIs = new List<bool>();
				foreach (var line2 in line)
				{
					var r = _service.CheckPointConnectToLed(line2, layouts);
					ledIs.Add(r);
				}
				tempR1.Add(line, ledIs); 
			} 

		}

		private CadDocument GetDocument()
		{

			CadDocument doc;
			using (DwgReader reader = new DwgReader(_file))
			{
				doc = reader.Read();
			}
			return doc;
		}
	}
}