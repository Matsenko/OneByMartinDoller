using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared.Model
{
	public class BlockItem
	{
		public string MainBlock { get; set; }
		public string SubBlock { get; set; }

		public override string ToString()
		{
			return $"{MainBlock} {SubBlock}";
		}
	}
}
