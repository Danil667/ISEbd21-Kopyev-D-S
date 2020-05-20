using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.Interfaces
{
	public interface IClientLogic
	{
		List<ClientViewModel> Read(ClientBindingModel model);
		void CreateOrUpdate(ClientBindingModel model);
		void Delete(ClientBindingModel model);

	}
}
