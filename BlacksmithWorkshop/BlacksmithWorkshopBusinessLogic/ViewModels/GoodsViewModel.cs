using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.ViewModels
{
	public class GoodsViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название изделия")]
		public string GoodsName { get; set; }
		[DisplayName("Цена")]
		public decimal Price { get; set; }
		public Dictionary<int, (string, int)> GoodsBillets { get; set; }
	}
}
