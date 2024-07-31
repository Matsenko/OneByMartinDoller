using System.Diagnostics;
using WebApplication1.Models;
using ACadSharp;

using OneByMartinDoller.GoogleSheet.Shared;
using OneByMartinDoller.Site.Services;
using OneByMartinDoller.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using OneByMartinDoller.GoogleSheet;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger; 
		private GoogleSheetInit _googleSheetInit;
		public HomeController(ILogger<HomeController> logger, GoogleSheetInit googleSheet)
		{
			_logger = logger; 
			_googleSheetInit = googleSheet;

		}

		public IActionResult Index()
		{
   
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpPost]
		public IActionResult UploadFile()
		{
			var file = Request.Form.Files["file"];

			if (file != null && file.Length > 0)
			{
				var fileExtension = Path.GetExtension(file.FileName);

				if (fileExtension.ToLower() != ".dwg")
				{
					ViewBag.Message = "Please upload a DWG file.";
					return View("Index");
				}

				try
				{
					using (var memoryStream = new MemoryStream())
					{
						file.CopyTo(memoryStream);
						memoryStream.Position = 0;
						CadDocument cadDocument;
						using (var reader = new ACadSharp.IO.DwgReader(memoryStream))
						{
							cadDocument = reader.Read();
						}

						DwgProccesingService _dwgProccessingService = new DwgProccesingService();
						var viewModelList = new List<DwgProcessingModel>();
						var processingResult = _dwgProccessingService.GetProccessing(cadDocument);

						foreach (var room in processingResult)
						{
							var cleanedKey = _dwgProccessingService.ExtractLastValue(room.Key);
							var cleanedValue = new Dictionary<string, int>();

							foreach (var pBlock in room.Value)
							{
								var cleanedPBlockKey = _dwgProccessingService.ExtractLastValue(pBlock.Key);

							
								if (cleanedValue.TryGetValue(cleanedPBlockKey, out int existingValue))
								{
									cleanedValue[cleanedPBlockKey] = existingValue + pBlock.Value; 
								}
								else
								{
									cleanedValue[cleanedPBlockKey] = pBlock.Value;
								}
							}

							var cleanedRoomName = _dwgProccessingService.CleanRoomName(room.Key);
							var viewModel = new DwgProcessingModel
							{
								RoomName = cleanedRoomName,
								PBlocks = cleanedValue
							};

							viewModelList.Add(viewModel);
						}

						// Assuming _googleSheetInit is properly initialized somewhere in your class
						_googleSheetInit._processingModels = viewModelList;
						_googleSheetInit.WriteToGoogleSheet();

						ViewBag.Message = "File uploaded successfully and sent to another project for processing.";
						ViewBag.SpreadSheetId = LibraryParametrs.SpreadSheetId;
						return View("ProcessDwgFile", viewModelList);
					}
				}
				catch (Exception ex)
				{
					ViewBag.Message = $"Error processing DWG file: {ex.Message}";
					return View("Index");
				}
			}

			ViewBag.Message = "No file uploaded.";
			return View("Index");
		}

	}
}
