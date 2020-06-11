using BlacksmithWorkshopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.ViewModels
{
	public class BilletsViewModel : BaseViewModel
	{
		[Column(title: "Заготовка", gridViewAutoSize: GridViewAutoSize.Fill)]
		public string BilletsName { get; set; }
		public override List<string> Properties() => new List<string>
		{
			"BilletsName"
		};
	}
}
