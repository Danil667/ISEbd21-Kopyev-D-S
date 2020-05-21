using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.BindingModels
{
	public class CreateOrderBindingModel
	{
		public int GoodsId { get; set; }
		public int Count { get; set; }
		public decimal Sum { get; set; }
	}
}
