using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopFileImplement.Models
{
	public class GoodsBillets
	{
		public int Id { get; set; }
		public int GoodsId { get; set; }
		public int BilletsId { get; set; }
		public int Count { get; set; }
	}
}
