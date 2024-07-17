using OneByMartinDoller.GoogleSheet.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.GoogleSheet
{
	public class GoogleSheetInit
	{
		public readonly string _spreadSheetId;
		public readonly string _sheetName;
		public readonly string _credentialsPath;
		public readonly string _projectName;
		public List<DwgProcessingModel> _processingModels;
		public GoogleSheetInit(string spreadSheetId,string sheetName,string credentialsPath,string projectName,List<DwgProcessingModel> processingModels)
		{
			_spreadSheetId = spreadSheetId;
			_sheetName = sheetName;
			_credentialsPath = credentialsPath;
			_projectName = projectName;
			_processingModels = processingModels;

		}
		public void WriteToGoogleSheet()
		{
			var writer = new GoogleSheetsWriter(_projectName,_credentialsPath);
			writer.WriteToGoogleSheet(_processingModels, _spreadSheetId, _sheetName);
		}

	}
}
