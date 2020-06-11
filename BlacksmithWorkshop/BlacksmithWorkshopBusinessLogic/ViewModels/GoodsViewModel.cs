using BlacksmithWorkshopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.ViewModels
{
	[DataContract]
	public class GoodsViewModel : BaseViewModel
	{
		[DataMember]
		public int Id { get; set; }
		[Column(title: "Название товара", gridViewAutoSize: GridViewAutoSize.Fill)]
		[DataMember]
		public string GoodsName { get; set; }
		[Column(title: "Цена", width: 50)]
		[DataMember]
		public decimal Price { get; set; }
		[DataMember]
		public Dictionary<int, (string, int)> GoodsBilletss { get; set; }
		public override List<string> Properties() => new List<string>
		{
			"Id",
			"GoodsName",
			"Price"
		};
	}
}
