using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.ViewModels
{
	public class StorageBilletsViewModel
	{
		public int Id { get; set; }
		public int StorageId { get; set; }
		public int BilletsId { get; set; }
		[DisplayName("Название заготовки")]
		public string BilletsName { get; set; }
		[DisplayName("Количество")]
		public int Count { get; set; }
	}
}
