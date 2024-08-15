using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using OneByMartinDoller.GoogleSheet.Shared;
using OneByMartinDoller.Shared.Model;

namespace OneByMartinDoller.GoogleSheet
{
	public class GoogleSheetsWriter
	{
		private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets,DriveService.Scope.Drive};
		private readonly string _applicationName;
		private readonly string _credentialsFileName;
		private SheetsService _service;
		private DriveService _driveService;

		public GoogleSheetsWriter(string applicationName, string credentialsFileName)
		{
			_applicationName = applicationName;
			_credentialsFileName = credentialsFileName;
			InitializeService();
		}

		private void InitializeService()
		{
			UserCredential credential;

			using (var stream = new FileStream(_credentialsFileName, FileMode.Open, FileAccess.Read))
			{
				string credPath = "token.json";
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Scopes, 
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
			}

			_service = new SheetsService(new BaseClientService.Initializer()
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



		public async Task<string> CopySpreadsheetAsync(string sourceSpreadsheetId, string copyTitle)
		{
			try
			{

				var copyRequest = _driveService.Files.Copy(new Google.Apis.Drive.v3.Data.File()
				{
					Name = copyTitle 
				}, sourceSpreadsheetId);

				var file = await copyRequest.ExecuteAsync();

				return file.Id; 
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при копировании таблицы: {ex.Message}");
				return string.Empty;
			}
		}

		public void WriteToGoogleSheet(
	Dictionary<FloorTypes, List<DGWViewModel>> modelView,
	string spreadsheetId,
	string sheetName,
	string startCell)
		{
			var valueRange = new ValueRange();
			var oblist = new List<IList<object>>();
			foreach (var entry in modelView)
			{
				var floorType = entry.Key;
				var viewModels = entry.Value;

				foreach (var viewModel in viewModels)
				{
					var roomName = viewModel.RoomName;

					foreach (var circuit in viewModel.Circuits)
					{
						var circuitName = circuit.Name;

						foreach (var blockItem in circuit.CuirtsItems)
						{
							var row = new List<object>
					{
	/*					floorType.ToString(),          
                        roomName,                      
                        circuitName,                   
                        blockItem.Key.ToString(),      
                        blockItem.Value      */  
						blockItem.Value,
						circuitName,
						roomName,
						floorType.ToString(),
						blockItem.Key.ToString()
					};
							oblist.Add(row);
						}
					}
				}
			}

			valueRange.Values = oblist;

	
			string range = $"{sheetName}!{startCell}";

			var updateRequest = _service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
			updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
			updateRequest.Execute();
		}



	}
}
