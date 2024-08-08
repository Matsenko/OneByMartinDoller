namespace OneByMartinDoller.Site.Services.IServices
{
	public interface IFailLoadLimitsService
	{

		public void UploadFile();
		public void DisplayUploadStatus();
		public int ReadAmountOfUpLoadFiles();
		public void WriteAmountOfUpLoadFiles(int amount);
	}
}
