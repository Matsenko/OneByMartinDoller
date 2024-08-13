using CsvHelper;
using CsvHelper.Configuration;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using OneByMartinDoller.Shared.Services;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared
{
	public class CsvChanger
	{
		private  string _inputFilePath;
		private  string _outputFilePath;
		private readonly int _startRow;
		private readonly int _endRow;
		private List<List<string>> _records;
		private readonly Dictionary<int, string> _rowValues;
		public CsvChanger(string inputFilePath, string outputFilePath, int startRow, int endRow, Dictionary<int, string> rowValues)
		{
			_inputFilePath = inputFilePath;
			_outputFilePath = outputFilePath;
			_startRow = startRow;
			_records = new List<List<string>>();
			_endRow = endRow;
			_rowValues = rowValues;
		}

		public void LoadCsv()
		{
			using (var reader = new StreamReader(_inputFilePath))
			using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				HasHeaderRecord = false
			}))
			{
				while (csv.Read())
				{
					var record = new List<string>();
					for (int i = 0; csv.TryGetField(i, out string field); i++)
					{
						record.Add(field);
					}
					_records.Add(record);
				}
			}
		}

		public void ModifyRecords()
		{
			for (int i = _startRow; i <= _endRow && i < _records.Count; i++)
			{
				if (_records[i].Count > 1 && _rowValues.ContainsKey(i))
				{
					_records[i][1] = _rowValues[i];
				}
			}
		}

		public void SaveCsv()
		{
			using (var writer = new StreamWriter(_outputFilePath))
			using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				HasHeaderRecord = false
			}))
			{
				foreach (var record in _records)
				{
					foreach (var field in record)
					{
						csv.WriteField(field);
					}
					csv.NextRecord();
				}
			}
		}
		private void UploadToGoogleDrive(string filePath)
		{
			string[] Scopes = { DriveService.Scope.DriveFile };
			string ApplicationName = LibraryParametrs.ProjectName;

			UserCredential credential;
			using (var stream = new FileStream(LibraryParametrs.CredentialsPath, FileMode.Open, FileAccess.Read))
			{
				string credPath = "token.json";
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Scopes,
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
			}

			var service = new DriveService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,
			});

			var fileMetadata = new Google.Apis.Drive.v3.Data.File()
			{
				Name = Path.GetFileName(filePath)
			};
			FilesResource.CreateMediaUpload request;
			using (var stream = new FileStream(filePath, FileMode.Open))
			{
				request = service.Files.Create(
					fileMetadata, stream, "text/csv");
				request.Fields = "id";
				request.Upload();
			}

			var file = request.ResponseBody;
			Console.WriteLine("File ID: " + file.Id);
		}
	
		public async Task ProcessCsv()
		{
			LoadCsv();
			ModifyRecords();
			SaveCsv();
			UploadToGoogleDrive(_outputFilePath);
		}
	}

}
