using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.BindingModels
{
	public class StorageBilletsBindingModel
	{
		public int Id { get; set; }
		public int StorageId { get; set; }
		public int BilletsId { get; set; }
		public int Count { get; set; }
	}
}
