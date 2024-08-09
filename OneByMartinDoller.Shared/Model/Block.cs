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
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			var other = (BlockItem)obj;
			return MainBlock == other.MainBlock && SubBlock == other.SubBlock;
		}


		public override int GetHashCode()
		{
			int hashMainBlock = MainBlock == null ? 0 : MainBlock.GetHashCode();
			int hashSubBlock = SubBlock == null ? 0 : SubBlock.GetHashCode();
			return hashMainBlock ^ hashSubBlock;
		}
	}
}
