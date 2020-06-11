using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.BindingModels
{
	public class StorageBindingModel
	{
		public int Id { get; set; }
		public string StorageName { get; set; }
		public List<StorageBilletsBindingModel> StorageBilletss { get; set; }
	}
}
