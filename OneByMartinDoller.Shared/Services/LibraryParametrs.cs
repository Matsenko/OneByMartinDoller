﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared.Services
{
	public static class LibraryParametrs
	{
		#region GoogleSheetInit
		// Google Sheet ID
		private static readonly string _spreadSheetId = "1ICVAFk-VP90By7OZrrykMqql0pdQ0FWT5aCbKYDZMSo";

		// Sheet name
		private static readonly string _sheetName = "Лист1";

		// Path to credentials file
		private static readonly string _credentialsPath = "credentials.json";

		// Project name
		private static readonly string _projectName = "My Project 39375";

		// Properties to access the fields
		public static string SpreadSheetId => _spreadSheetId;
		public static string SheetName => _sheetName;
		public static string CredentialsPath => _credentialsPath;
		public static string ProjectName => _projectName;
		#endregion

		#region CsvChanger

		public static readonly string _csvPath = "inputCsvFile.csv";
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


	}
}
