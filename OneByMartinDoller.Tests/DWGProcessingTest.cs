using ACadSharp.Entities;
using ACadSharp.IO;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using ACadSharp;
using OneByMartinDoller.Shared.Services;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			//var items=_service.GetPolylinesForItem(GetDocument());

		}

		[TestMethod]
		public void GetVerticesFromArc_14VerticesConnected()
		{
			var doc = GetDocument();
			var layouts = _service.GetlayEntiTypeEntity(doc); 
			var circLayout = layouts["E-LUM-CIRC"];
			var lines = new List<Line>();

			var arcList = circLayout[ObjectType.ARC].Select(x => x as Arc).ToList();
			var result=_service.GetLinesListsFromsArcList(arcList);

			Assert.AreEqual(14, result.Count);

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