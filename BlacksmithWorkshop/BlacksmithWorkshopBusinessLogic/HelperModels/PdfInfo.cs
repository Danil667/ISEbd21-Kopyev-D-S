using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.HelperModels
{
	class PdfInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ReportGoodsBilletsViewModel> GoodsBilletss { get; set; }
	}
}
