using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.ViewModels
{
	public class GoodsBilletsViewModel
	{
		public int Id { get; set; }
		public int GoodsID { get; set; }
		public int BilletsID { get; set; }
		[DisplayName("Компонент")]
		public string BilletsName { get; set; }
		[DisplayName("Количество")]
		public int Count { get; set; }
	}
}
