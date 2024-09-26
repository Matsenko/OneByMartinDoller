using System.Diagnostics;
using WebApplication1.Models;
using ACadSharp;
using OneByMartinDoller.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using OneByMartinDoller.GoogleSheet;
using OneByMartinDoller.Shared.Model;
using System.Text.RegularExpressions;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger; 
		private GoogleSheetInit _googleSheetInit;
		public IConfiguration Configuration { get; }

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
						var extractedDoc = _dwgProccessingService.ParseDGW(cadDocument);

						ViewBag.Message = "File uploaded successfully and sent to another project for processing.";
			
						ViewBag.SpreadSheetId = LibraryParametrs.SpreadSheetId;
						
						var modelView = new Dictionary<FloorTypes, List<DGWViewModel>>();
						foreach (var room in extractedDoc)
						{
							if (!modelView.ContainsKey(room.FloorType))
								modelView.Add(room.FloorType, new List<DGWViewModel>());
							if (room.Circuits == null)
								continue;
							foreach (var circuit in room.Circuits)
							{
								var transformedItems = new Dictionary<BlockItem, int>();

								foreach (var item in circuit.CuirtsItems)
								{
									var blockItem = item.Key;
									var value = item.Value;

									BlockItem transformedBlockItem = TransformBlockItem(blockItem, out int transformedValue);

				
									int finalValue = transformedValue * value;


									if (transformedItems.ContainsKey(transformedBlockItem))
									{
										transformedItems[transformedBlockItem] += finalValue;
									}
									else
									{
										transformedItems[transformedBlockItem] = finalValue;
									}
								}

								circuit.CuirtsItems = transformedItems;
							}

							modelView[room.FloorType].Add(room);
						}


						BlockItem TransformBlockItem(BlockItem item, out int transformedValue)
						{
							transformedValue = 1;
							 
							return item;
						}
						_googleSheetInit._processingModels = modelView;
						_googleSheetInit.WriteToGoogleSheet();
						return View("ProcessDwgFile", modelView);
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
