using ACadSharp;
using ACadSharp.IO;
using OneByMartinDoller.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Tests
{
	[TestClass]
	public class DWGProcessing20Testing
	{
		private readonly DwgProccesingService20 _service = new DwgProccesingService20();
		const string _file = @"D:\CodeLuxSolutions\UpWork\Kaige Naidoo\OneByMartinDoller\OneByMartinDoller\OneByMartinDoller.Tests\Resources\Drawing4 TEsting.dwg";

		[TestMethod]
		public void DWGProcessing20_GetLayout()
		{
			var layouts = _service.GetlayEntiTypeEntity(GetDocument());
			var roomVertices = _service.GetRoomVertices(layouts); 
			var circLayout = layouts["E-LUM-CIRC"];
			//var lines = new List<Line>();
		}

		[TestMethod]
		public void DWGProcessing20_ParseDocument()
		{
			var doc = GetDocument(_file);
			var parsedDocument= _service.ParseDGW(doc);
		}

		private CadDocument GetDocument(string? path = null)
		{
			if (path == null)
				path = _file;
			CadDocument doc;
			using (DwgReader reader = new(path))
			{
				doc = reader.Read();
			}
			return doc;
		}
	}
}
