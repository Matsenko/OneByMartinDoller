using ACadSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared.Services.IServices
{
	public interface IDwgProccessingService
	{
		public Dictionary<string, Dictionary<string, int>> GetProccessing(CadDocument doc);
	}
}

