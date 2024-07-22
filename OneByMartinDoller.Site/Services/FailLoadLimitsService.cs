using OneByMartinDoller.Site.Services.IServices;
using System;
using System.IO;

namespace OneByMartinDoller.Site.Services
{

	public class FailLoadLimits:IFailLoadLimitsService
	{
		private const string FileName = "upload_limits.txt";
		public static readonly string USER_MESSAGE = "You have reached the file upload limit.";

		public int AmountOfUpLoadFiles { get; private set; }
		public bool CanUploadFile => AmountOfUpLoadFiles < AvaliableUploadFileCount;

		public int AvaliableUploadFileCount = 7;

		public FailLoadLimits()
		{

			ReadAmountOfUpLoadFiles();
		}

		public void UploadFile()
		{
			if (!CanUploadFile)
			{
				Console.WriteLine(USER_MESSAGE);
				return;
			}

			AmountOfUpLoadFiles++;
			WriteAmountOfUpLoadFiles();
		}

		public void DisplayUploadStatus()
		{
			if (CanUploadFile)
			{
				Console.WriteLine($"You have uploaded {AmountOfUpLoadFiles} files. You have {AvaliableUploadFileCount - AmountOfUpLoadFiles} files remaining.");
			}
			else
			{
				Console.WriteLine(USER_MESSAGE);
			}
		}

		public void ReadAmountOfUpLoadFiles()
		{
			try
			{
				if (File.Exists(FileName))
				{
					string data = File.ReadAllText(FileName);
					if (int.TryParse(data, out int amount))
					{
						AmountOfUpLoadFiles = amount;
					}
					else
					{
						AmountOfUpLoadFiles = 0;
						WriteAmountOfUpLoadFiles(); 
					}
				}
				else
				{
					WriteAmountOfUpLoadFiles(); 
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error reading file: {ex.Message}");
			}
		}

		public void WriteAmountOfUpLoadFiles()
		{
			try
			{
				File.WriteAllText(FileName, AmountOfUpLoadFiles.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error writing file: {ex.Message}");
			}
		}
	}

}
