﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared.Model
{
	public class DGWViewModel
	{
		public FloorTypes FloorType { get; set; }
		public string RoomName { get; set; }
		List<Circuit> Circuits { get; set; }
	}
}
