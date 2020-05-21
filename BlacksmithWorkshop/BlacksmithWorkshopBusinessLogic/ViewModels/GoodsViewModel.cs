﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.ViewModels
{
	[DataContract]
	public class GoodsViewModel
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		[DisplayName("Название изделия")]
		public string GoodsName { get; set; }
		[DataMember]
		[DisplayName("Цена")]
		public decimal Price { get; set; }
		[DataMember]
		public Dictionary<int, (string, int)> GoodsBilletss { get; set; }
	}
}
