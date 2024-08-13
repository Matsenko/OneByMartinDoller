using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OneByMartinDoller.GoogleSheet.Shared;
using System.Net;

namespace OneByMartinDoller.GoogleSheet
{
	public class GoogleSheetsWriter
	{
		private static readonly string[] SheetsScopes = { SheetsService.Scope.Spreadsheets };
		private static readonly string[] DriveScopes = { DriveService.Scope.Drive };
		private readonly string _applicationName;
		private readonly string _credentialsFileName;
		private SheetsService _sheetsService;
		private DriveService _driveService;

		public GoogleSheetsWriter(string applicationName, string credentialsFileName)
		{
			_applicationName = applicationName;
			_credentialsFileName = credentialsFileName;
			InitializeServices();
		}

		private void InitializeServices()
		{
			UserCredential credential;

			using (var stream = new FileStream(_credentialsFileName, FileMode.Open, FileAccess.Read))
			{
				string credPath = "token.json";
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					SheetsScopes.Concat(DriveScopes).ToArray(),
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
			}

			_sheetsService = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = _applicationName,
			});

			_sheetsService = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = _applicationName,
			});

			_driveService = new DriveService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = _applicationName,
			});
		}

		public async Task<string> CreateSpreadsheetAsync(string title)
		{
			try
			{
				var requestBody = new Spreadsheet()
				{
					Properties = new SpreadsheetProperties()
					{
						Title = title
					}
				};

				var request = _sheetsService.Spreadsheets.Create(requestBody);
				var response = await request.ExecuteAsync();

				return response.SpreadsheetId;
			}
			catch (Exception ex)
			{
				
				return string.Empty;
			}

		}
		public async Task CopySheetsToNewSpreadsheetAsync(string sourceSpreadsheetId, string newSpreadsheetTitle)
		{

			string newSpreadsheetId = await CreateSpreadsheetAsync(newSpreadsheetTitle);
			var sheetParams=	_sheetsService.Spreadsheets.Sheets.CopyTo(new CopySheetToAnotherSpreadsheetRequest(), sourceSpreadsheetId, 0).Execute();
			/*	var sourceSheets = await GetSheetsFromSpreadsheetAsync(sourceSpreadsheetId);

				foreach (var sheet in sourceSheets)
				{
					await CopySheetToSpreadsheetAsync(sourceSpreadsheetId, newSpreadsheetId, sheet);
				}*/
		}

		private async Task<IList<Sheet>> GetSheetsFromSpreadsheetAsync(string spreadsheetId)
		{
			UserCredential credential;

			using (var stream = new FileStream(_credentialsFileName, FileMode.Open, FileAccess.Read))
			{
				string credPath = "token.json";
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					SheetsScopes.Concat(DriveScopes).ToArray(),
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
			}


			var sheetsService = new SheetsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = _applicationName,
			});
			var request = sheetsService.Spreadsheets.Get(spreadsheetId);
			var response = await request.ExecuteAsync();
			return response.Sheets;
		}

		private async Task CopySheetToSpreadsheetAsync(string sourceSpreadsheetId, string targetSpreadsheetId, Sheet sheet)
		{
			var requestBody = new CopySheetToAnotherSpreadsheetRequest()
			{
				DestinationSpreadsheetId = targetSpreadsheetId
			};

			var request = _sheetsService.Spreadsheets.Sheets.CopyTo(requestBody, sourceSpreadsheetId, sheet.Properties.SheetId.Value);
			await request.ExecuteAsync();
		}

		public void WriteToGoogleSheet(List<DwgProcessingModel> models, string spreadsheetId, string sheetName)
		{
			var valueRange = new ValueRange();
			var oblist = new List<IList<object>>();

			var headers = GetHeaders();
			oblist.Add(headers);

			foreach (var model in models)
			{
				foreach (var pblock in model.PBlocks)
				{
					var row = new List<object>
					{
						model.RoomName,
						pblock.Key,
						pblock.Value
					};
					oblist.Add(row);
				}
			}

			valueRange.Values = oblist;

			var updateRequest = _sheetsService.Spreadsheets.Values.Update(valueRange, spreadsheetId, $"{sheetName}!A1");
			updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
			updateRequest.Execute();
		}

		private IList<object> GetHeaders()
		{
			var headers = new List<object>
			{
				"Room Name",
				"P-Block Identifier",
				"Count"
			};
			return headers;
		}
	}
}
