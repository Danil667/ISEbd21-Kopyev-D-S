using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopListImplement.Implements
{
	public class StorageLogic : IStorageLogic
	{
		private readonly DataListSingleton source;
		public StorageLogic()
		{
			source = DataListSingleton.GetInstance();
		}
		public List<StorageViewModel> GetList()
		{
			List<StorageViewModel> result = new List<StorageViewModel>();
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				List<StorageBilletsViewModel> StorageBilletss = new
	List<StorageBilletsViewModel>();
				for (int j = 0; j < source.StorageBilletss.Count; ++j)
				{
					if (source.StorageBilletss[j].StorageId == source.Storages[i].Id)
					{
						string BilletsName = string.Empty;
						for (int k = 0; k < source.Billetss.Count; ++k)
						{
							if (source.StorageBilletss[j].BilletsId ==
						   source.Billetss[k].Id)
							{
								BilletsName = source.Billetss[k].BilletsName;
								break;
							}
						}
						StorageBilletss.Add(new StorageBilletsViewModel
						{
							Id = source.StorageBilletss[j].Id,
							StorageId = source.StorageBilletss[j].StorageId,
							BilletsId = source.StorageBilletss[j].BilletsId,
							BilletsName = BilletsName,
							Count = source.StorageBilletss[j].Count
						});
					}
				}
				result.Add(new StorageViewModel
				{
					Id = source.Storages[i].Id,
					StorageName = source.Storages[i].StorageName,
					StorageBilletss = StorageBilletss
				});
			}
			return result;
		}
		public StorageViewModel GetElement(int id)
		{
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				List<StorageBilletsViewModel> StorageBilletss = new
	List<StorageBilletsViewModel>();
				for (int j = 0; j < source.StorageBilletss.Count; ++j)
				{
					if (source.StorageBilletss[j].StorageId == source.Storages[i].Id)
					{
						string BilletsName = string.Empty;
						for (int k = 0; k < source.Billetss.Count; ++k)
						{
							if (source.StorageBilletss[j].BilletsId ==
						   source.Billetss[k].Id)
							{
								BilletsName = source.Billetss[k].BilletsName;
								break;
							}
						}
						StorageBilletss.Add(new StorageBilletsViewModel
						{
							Id = source.StorageBilletss[j].Id,
							StorageId = source.StorageBilletss[j].StorageId,
							BilletsId = source.StorageBilletss[j].BilletsId,
							BilletsName = BilletsName,
							Count = source.StorageBilletss[j].Count
						});
					}
				}
				if (source.Storages[i].Id == id)
				{
					return new StorageViewModel
					{
						Id = source.Storages[i].Id,
						StorageName = source.Storages[i].StorageName,
						StorageBilletss = StorageBilletss
					};
				}
			}
			throw new Exception("Элемент не найден");
		}
		public void AddElement(StorageBindingModel model)
		{
			int maxId = 0;
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				if (source.Storages[i].Id > maxId)
				{
					maxId = source.Storages[i].Id;
				}
				if (source.Storages[i].StorageName == model.StorageName)
				{
					throw new Exception("Уже есть склад с таким названием");
				}
			}
			source.Storages.Add(new Storage
			{
				Id = maxId + 1,
				StorageName = model.StorageName
			});
		}
		public void UpdElement(StorageBindingModel model)
		{
			int index = -1;
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				if (source.Storages[i].Id == model.Id)
				{
					index = i;
				}
				if (source.Storages[i].StorageName == model.StorageName &&
				source.Storages[i].Id != model.Id)
				{
					throw new Exception("Уже есть склад с таким названием");
				}
			}
			if (index == -1)
			{
				throw new Exception("Элемент не найден");
			}
			source.Storages[index].StorageName = model.StorageName;
		}
		public void DelElement(int id)
		{
			for (int i = 0; i < source.StorageBilletss.Count; ++i)
			{
				if (source.StorageBilletss[i].StorageId == id)
				{
					source.StorageBilletss.RemoveAt(i--);
				}
			}
			for (int i = 0; i < source.Storages.Count; ++i)
			{
				if (source.Storages[i].Id == id)
				{
					source.Storages.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		public void FillStorage(StorageBilletsBindingModel model)
		{
			int foundItemIndex = -1;
			for (int i = 0; i < source.StorageBilletss.Count; ++i)
			{
				if (source.StorageBilletss[i].BilletsId == model.BilletsId
					&& source.StorageBilletss[i].StorageId == model.StorageId)
				{
					foundItemIndex = i;
					break;
				}
			}
			if (foundItemIndex != -1)
			{
				source.StorageBilletss[foundItemIndex].Count =
					source.StorageBilletss[foundItemIndex].Count + model.Count;
			}
			else
			{
				int maxId = 0;
				for (int i = 0; i < source.StorageBilletss.Count; ++i)
				{
					if (source.StorageBilletss[i].Id > maxId)
					{
						maxId = source.StorageBilletss[i].Id;
					}
				}
				source.StorageBilletss.Add(new StorageBillets
				{
					Id = maxId + 1,
					StorageId = model.StorageId,
					BilletsId = model.BilletsId,
					Count = model.Count
				});
			}
		}
	}
}
