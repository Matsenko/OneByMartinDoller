using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared
{
	class CsvChanger
	{
		private readonly string _inputFilePath;
		private readonly string _outputFilePath;
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

		public void ProcessCsv()
		{
			LoadCsv();
			ModifyRecords();
			SaveCsv();
		}
	}

}
