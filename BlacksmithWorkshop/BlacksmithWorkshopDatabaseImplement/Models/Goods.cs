using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
	public class Goods
	{
		public int Id { get; set; }
		[Required]
		public string GoodsName { get; set; }
		[Required]
		public decimal Price { get; set; }
		public virtual List<GoodsBillets> GoodsBilletss { get; set; }
		public virtual List<Order> Orders { get; set; }
	}
}
