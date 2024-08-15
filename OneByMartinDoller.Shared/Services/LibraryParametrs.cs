using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace OneByMartinDoller.Shared.Services
{
	public static class LibraryParametrs
	{
		#region GoogleSheetInit

		// Google Sheet ID

		public static string SpreadSheetId { get; private set; }
		public static string SheetName { get; private set; }
		public static string CredentialsPath { get; private set; }
		public static string ProjectName { get; private set; }
		public static string StartCell { get; private set; }

		#endregion

		#region CsvChanger

		public static readonly string _csvPath = "C:\\Users\\vovam\\Downloads\\Test.csv";
		public static readonly string _outputCsvPath = "outputCsvFile.csv";
		public static readonly int _startRow = 1;
		public static readonly int _endRow = 3;
		public static readonly Dictionary<int, string> _rowValues = new Dictionary<int, string>
		{
			{ 1, "Value1" },
			{ 2, "Value2" },
			{ 3, "Value3" }
		};
		#endregion
		public static void Initialize(IConfiguration configuration)
		{
			// Initialize Google Sheets settings
			SpreadSheetId = configuration["GoogleSheets:SpreadSheetId"];
			SheetName = configuration["GoogleSheets:SheetName"];
			CredentialsPath = configuration["GoogleSheets:CredentialsPath"];
			ProjectName = configuration["GoogleSheets:ProjectName"];
			StartCell = configuration["GoogleSheets:StartCell"];

	
		}

	}
}
