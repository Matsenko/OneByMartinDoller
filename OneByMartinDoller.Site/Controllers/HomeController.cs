using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using ACadSharp;

using OneByMartinDollerSite.Models;
using OneByMartinDoller.Site.Services;
using OneByMartinDoller.Shared.Services;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly FailLoadLimits _failLoadLimitsService;
		public HomeController(ILogger<HomeController> logger, FailLoadLimits failLoadLimitsService)
		{
			_logger = logger;
			_failLoadLimitsService = failLoadLimitsService;

		}

		public IActionResult Index()
		{
			ViewBag.Message = _failLoadLimitsService.CanUploadFile ?
			$"You have uploaded {_failLoadLimitsService.AmountOfUpLoadFiles} files. You have {_failLoadLimitsService.AvaliableUploadFileCount - _failLoadLimitsService.AmountOfUpLoadFiles} files remaining." :
			FailLoadLimits.USER_MESSAGE;
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

			if (file != null && file.Length > 0 && _failLoadLimitsService.CanUploadFile)
			{
				_failLoadLimitsService.UploadFile();
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
						var viewModelList = new List<DwgProcessingViewModel>();
						var processingResult = _dwgProccessingService.GetProccessing(cadDocument);
						foreach (var room in processingResult)
						{
							var cleanedKey = ACadSharp.Examples.Program.ExtractLastValue(room.Key);
							Dictionary<string, int> cleanedValue = new Dictionary<string, int>();
							foreach(var pBlock in room.Value)
							{
								var cleanedPBlockKey = ACadSharp.Examples.Program.ExtractLastValue(pBlock.Key);
								cleanedValue.Add(cleanedPBlockKey, pBlock.Value);
							}
							var cleanedRoomName = ACadSharp.Examples.Program.CleanRoomName(room.Key);
							var viewModel = new DwgProcessingViewModel
							{
								RoomName = cleanedRoomName,
								PBlocks = cleanedValue
							};
					
							viewModelList.Add(viewModel);
						}

						ViewBag.Message = "File uploaded successfully and sent to another project for processing.";
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
