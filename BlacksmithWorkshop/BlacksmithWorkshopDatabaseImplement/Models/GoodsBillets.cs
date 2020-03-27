using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
	public class GoodsBillets
	{
		public int Id { get; set; }
		public int GoodsId { get; set; }
		public int BilletsId { get; set; }
		[Required]
		public int Count { get; set; }
		public virtual Billets Billets { get; set; }
		public virtual Goods Goods { get; set; }
	}
}
