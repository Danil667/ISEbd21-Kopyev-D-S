using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.Interfaces
{
	public interface IGoodsLogic
	{
		List<GoodsViewModel> Read(GoodsBindingModel model);
		void CreateOrUpdate(GoodsBindingModel model);
		void Delete(GoodsBindingModel model);
	}
}
