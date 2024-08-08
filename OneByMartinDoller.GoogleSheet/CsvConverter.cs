using CsvHelper.Configuration;
using CsvHelper;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneByMartinDoller.GoogleSheet.Shared;

namespace OneByMartinDoller.GoogleSheet
{
	public static class CsvConverter
	{
		public static string ConvertToCsv(List<DwgProcessingModel> models)
		{
			var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				Delimiter = ",",
				Encoding = Encoding.UTF8
			};

			using var writer = new StringWriter();
			using (var csv = new CsvWriter(writer, csvConfig))
			{
				csv.WriteField("Room Name");
				csv.WriteField("P-Block Identifier");
				csv.WriteField("Count");
				csv.NextRecord();

				foreach (var model in models)
				{
					foreach (var pblock in model.PBlocks)
					{
						csv.WriteField(model.RoomName);
						csv.WriteField(pblock.Key);
						csv.WriteField(pblock.Value);
						csv.NextRecord();
					}
				}
			}

			return writer.ToString();
		}
	}
	}
