using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared.Services
{
	public static class GoogleSheetSettings
	{
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
	}
}
