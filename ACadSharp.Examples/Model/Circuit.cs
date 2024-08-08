using ACadSharp.Examples.Model;
using System.Collections.Generic;

namespace OneByMartinDoller.Shared.Model
{
	public  class Circuit
	{
		public string Name { get; set; }
		public string Cuirts { get; set; }

		public Dictionary<BlockItem, int> CuirtsItems { get; set; }
	}
}