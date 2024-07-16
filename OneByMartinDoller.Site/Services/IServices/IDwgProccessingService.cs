using ACadSharp;

namespace OneByMartinDollerSite.Services.IServices
{
	public interface IDwgProccessingService
	{
		public Dictionary<string,Dictionary<string,int>> GetProccessing(CadDocument doc);
	}
}
