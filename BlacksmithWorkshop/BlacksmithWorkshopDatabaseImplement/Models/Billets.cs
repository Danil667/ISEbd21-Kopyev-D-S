using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
	public class Billets
	{
		public int Id { get; set; }
		[Required]
		public string BilletsName { get; set; }
		[ForeignKey("BilletsId")]
		public virtual List<GoodsBillets> GoodsBilletss { get; set; }
	}
}
