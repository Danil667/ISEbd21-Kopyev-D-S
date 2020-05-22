using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlacksmithWorkshopRestApi.Models
{
	public class GoodsModel
	{
		public int Id { get; set; }
		public string GoodsName { get; set; }
		public decimal Price { get; set; }
	}
}
