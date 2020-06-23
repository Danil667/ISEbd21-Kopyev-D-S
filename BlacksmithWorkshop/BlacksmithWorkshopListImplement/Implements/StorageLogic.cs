using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
						for (int k = 0; k < source.Billets.Count; ++k)
						{
							if (source.StorageBilletss[j].BilletsId ==
						   source.Billets[k].Id)
							{
								BilletsName = source.Billets[k].BilletsName;
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
						for (int k = 0; k < source.Billets.Count; ++k)
						{
							if (source.StorageBilletss[j].BilletsId ==
						   source.Billets[k].Id)
							{
								BilletsName = source.Billets[k].BilletsName;
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
		public bool CheckBilletssAvailability(int GoodsId, int GoodssCount)
		{
			bool result = true;
			var GoodsBilletss = source.GoodsBillets.Where(x => x.GoodsId == GoodsId);
			if (GoodsBilletss.Count() == 0) return false;
			foreach (var elem in GoodsBilletss)
			{
				int count = 0;
				var storageBilletss = source.StorageBilletss.FindAll(x => x.BilletsId == elem.BilletsId);
				count = storageBilletss.Sum(x => x.Count);
				if (count < elem.Count * GoodssCount)
					return false;
			}
			return result;
		}
		public void RemoveFromStorage(int GoodsId, int GoodssCount)
		{
			var GoodsBilletss = source.GoodsBillets.Where(x => x.GoodsId == GoodsId);
			if (GoodsBilletss.Count() == 0) return;
			foreach (var elem in GoodsBilletss)
			{
				int left = elem.Count * GoodssCount;
				var storageBilletss = source.StorageBilletss.FindAll(x => x.BilletsId == elem.BilletsId);
				foreach (var rec in storageBilletss)
				{
					int toRemove = left > rec.Count ? rec.Count : left;
					rec.Count -= toRemove;
					left -= toRemove;
					if (left == 0) break;
				}
			}
			return;
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