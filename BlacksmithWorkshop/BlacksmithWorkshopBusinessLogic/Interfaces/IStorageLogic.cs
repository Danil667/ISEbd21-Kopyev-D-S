using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.Interfaces
{
	public interface IStorageLogic
	{
		List<StorageViewModel> GetList();
		StorageViewModel GetElement(int id);
		void AddElement(StorageBindingModel model);
		void UpdElement(StorageBindingModel model);
		void DelElement(int id);
		void FillStorage(StorageBilletsBindingModel model);
	}
}
