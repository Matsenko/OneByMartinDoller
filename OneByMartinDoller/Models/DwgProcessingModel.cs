using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Models
{
	public class DwgProcessingModel
	{
		public string RoomName { get; set; }
		public Dictionary<string, int> PBlocks { get; set; }
	}
}
