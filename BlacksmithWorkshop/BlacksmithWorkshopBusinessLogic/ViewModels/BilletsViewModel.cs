using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.ViewModels
{
	public class BilletsViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название компонента")]
		public string BilletsName { get; set; }
	}
}
