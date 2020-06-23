using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlacksmithWorkshopFileImplement.Implements
{
	public class StorageLogic : IStorageLogic
	{
		private readonly FileDataListSingleton source;
		public StorageLogic()
		{
			source = FileDataListSingleton.GetInstance();
		}
		public List<StorageViewModel> GetList()
		{
			return source.Storages.Select(rec => new StorageViewModel
			{
				Id = rec.Id,
				StorageName = rec.StorageName,
				StorageBilletss = source.StorageBilletss.Where(z => z.StorageId == rec.Id).Select(x => new StorageBilletsViewModel
				{
					Id = x.Id,
					StorageId = x.StorageId,
					BilletsId = x.BilletsId,
					BilletsName = source.Billetss.FirstOrDefault(y => y.Id == x.BilletsId)?.BilletsName,
					Count = x.Count
				}).ToList()
			})
				.ToList();
		}
		public StorageViewModel GetElement(int id)
		{
			var elem = source.Storages.FirstOrDefault(x => x.Id == id);
			if (elem == null)
			{
				throw new Exception("Элемент не найден");
			}
			else
			{
				return new StorageViewModel
				{
					Id = id,
					StorageName = elem.StorageName,
					StorageBilletss = source.StorageBilletss.Where(z => z.StorageId == elem.Id).Select(x => new StorageBilletsViewModel
					{
						Id = x.Id,
						StorageId = x.StorageId,
						BilletsId = x.BilletsId,
						BilletsName = source.Billetss.FirstOrDefault(y => y.Id == x.BilletsId)?.BilletsName,
						Count = x.Count
					}).ToList()
				};
			}
		}

		public void AddElement(StorageBindingModel model)
		{

			var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName);
			if (elem != null)
			{
				throw new Exception("Уже есть склад с таким названием");
			}
			int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
			source.Storages.Add(new Storage
			{
				Id = maxId + 1,
				StorageName = model.StorageName
			});
		}
		public void UpdElement(StorageBindingModel model)
		{
			var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName && x.Id != model.Id);
			if (elem != null)
			{
				throw new Exception("Уже есть склад с таким названием");
			}
			var elemToUpdate = source.Storages.FirstOrDefault(x => x.Id == model.Id);
			if (elemToUpdate != null)
			{
				elemToUpdate.StorageName = model.StorageName;
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
		public void DelElement(int id)
		{
			var elem = source.Storages.FirstOrDefault(x => x.Id == id);
			if (elem != null)
			{
				source.Storages.Remove(elem);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		public void FillStorage(StorageBilletsBindingModel model)
		{
			var item = source.StorageBilletss.FirstOrDefault(x => x.BilletsId == model.BilletsId
					&& x.StorageId == model.StorageId);

			if (item != null)
			{
				item.Count += model.Count;
			}
			else
			{
				int maxId = source.StorageBilletss.Count > 0 ? source.StorageBilletss.Max(rec => rec.Id) : 0;
				source.StorageBilletss.Add(new StorageBillets
				{
					Id = maxId + 1,
					StorageId = model.StorageId,
					BilletsId = model.BilletsId,
					Count = model.Count
				});
			}
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
	}
}
