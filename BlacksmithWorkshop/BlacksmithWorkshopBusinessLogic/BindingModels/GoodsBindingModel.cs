using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.BindingModels
{
	public class GoodsBindingModel
	{
		public int? Id { get; set; }
		public string GoodsName { get; set; }
		public decimal Price { get; set; }
		public Dictionary<int, (string, int)> GoodsBillets { get; set; }
	}
}
