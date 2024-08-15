using OneByMartinDoller.GoogleSheet;
using OneByMartinDoller.GoogleSheet.Shared;
using OneByMartinDoller.Shared;
using OneByMartinDoller.Shared.Model;
GoogleSheetsWriter writer = new GoogleSheetsWriter("Test", "C:\\OneByMartinDoller\\OneByMartinDoller.Site\\credentials.json");
/*await writer.CopySpreadsheetAsync("1_q-Z9sCN2UIO4paPL6SeBdZ4qYzHkoMj-rGHWaKDaMU", "Test2222220");
*/
Dictionary<FloorTypes, List<DGWViewModel>> models = new Dictionary<FloorTypes, List<DGWViewModel>>();
List<DGWViewModel> list = new List<DGWViewModel>();
list.Add(new DGWViewModel
{
	Circuits = new List<Circuit>
	{
		new Circuit
		{
			CuirtsItems = new Dictionary<BlockItem, int>
			{
				{ new BlockItem { MainBlock = "Test1",SubBlock="Test4" }, 1 },
				{ new BlockItem { MainBlock = "Test2",SubBlock="Test3" }, 2 }
			}
		}
	},
	FloorType = FloorTypes.FirstFloor
});
models.Add(FloorTypes.FirstFloor, list);

writer.WriteToGoogleSheet(models, "158bxFX9KO-XBhQhPuEbDP1ij8mrjJzU_4BVKtcJVRL8", "NEW COUNTUP", "B13");

/*Dictionary<int,string> rowValues = new Dictionary<int, string>
{
	{ 1, "Value1" },
	{ 2, "Value2" },
	{ 3, "Value3" }
};
CsvChanger csvChanger = new CsvChanger("C:\\Users\\vovam\\Downloads\\Test.csv", "outPut.csv", 1, 5, rowValues);
csvChanger.ProcessCsv();*/