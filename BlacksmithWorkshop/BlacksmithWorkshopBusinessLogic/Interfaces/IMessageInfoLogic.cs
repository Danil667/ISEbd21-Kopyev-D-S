using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.Interfaces
{
	public interface IMessageInfoLogic
	{
		List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
		void Create(MessageInfoBindingModel model);
	}
}
