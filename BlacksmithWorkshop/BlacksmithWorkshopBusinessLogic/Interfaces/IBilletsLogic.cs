using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.Interfaces
{
	public interface IBilletsLogic
	{
		List<BilletsViewModel> Read(BilletsBindingModel model);
		void CreateOrUpdate(BilletsBindingModel model);
		void Delete(BilletsBindingModel model);
	}
}
