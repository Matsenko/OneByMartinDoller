using OneByMartinDoller.Site.Services.IServices;
using System;
using System.IO;

namespace OneByMartinDoller.Site.Services
{
	public class FailLoadLimits : IFailLoadLimitsService
	{
		public const string FileName = "upload_limits.txt";
		public static readonly string USER_MESSAGE = "You have reached the file upload limit.";

		public int _availableUploadFileCount = 5;
		public int AvaliableUploadFileCount => _availableUploadFileCount;

		public int AmountOfUpLoadFiles
		{
			get
			{
				return ReadAmountOfUpLoadFiles();
			}
		}

		public bool CanUploadFile => AmountOfUpLoadFiles < AvaliableUploadFileCount;

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

			int newAmount = AmountOfUpLoadFiles + 1;
			WriteAmountOfUpLoadFiles(newAmount);
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

		public int ReadAmountOfUpLoadFiles()
		{
			try
			{
				if (File.Exists(FileName))
				{
					string data = File.ReadAllText(FileName);
					if (int.TryParse(data, out int amount))
					{
						return amount;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error reading file: {ex.Message}");
			}
			return 0;
		}

		public void WriteAmountOfUpLoadFiles(int amount)
		{
			try
			{
				File.WriteAllText(FileName, amount.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error writing file: {ex.Message}");
			}
		}
	}
}