using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.HelperModels
{
	class WordInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<GoodsViewModel> Goodss { get; set; }
	}
}
