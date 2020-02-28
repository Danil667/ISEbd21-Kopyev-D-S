using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.BindingModels
{
	public class GoodsBilletsBindingModel
	{
		public int Id { get; set; }
		public int GoodsID { get; set; }
		public int BilletsID { get; set; }
		public int Count { get; set; }
	}
}
