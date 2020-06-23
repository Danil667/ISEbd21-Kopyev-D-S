using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopListImplement.Models
{
	public class StorageBillets
	{
		public int Id { get; set; }
		public int StorageId { get; set; }
		public int BilletsId { get; set; }
		public int Count { get; set; }
	}
}
