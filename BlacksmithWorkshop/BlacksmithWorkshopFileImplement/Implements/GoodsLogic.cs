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
	public class GoodsLogic : IGoodsLogic
	{
		private readonly FileDataListSingleton source;
		public GoodsLogic()
		{
			source = FileDataListSingleton.GetInstance();
		}
		public void CreateOrUpdate(GoodsBindingModel model)
		{
			Goods element = source.Goodss.FirstOrDefault(rec => rec.GoodsName ==
		   model.GoodsName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть товар с таким названием");
			}
			if (model.Id.HasValue)
			{
				element = source.Goodss.FirstOrDefault(rec => rec.Id == model.Id);
				if (element == null)
				{
					throw new Exception("Элемент не найден");
				}
			}
			else
			{
				int maxId = source.Goodss.Count > 0 ? source.Billetss.Max(rec =>
			   rec.Id) : 0;
				element = new Goods { Id = maxId + 1 };
				source.Goodss.Add(element);
			}
			element.GoodsName = model.GoodsName;
			element.Price = model.Price;
			source.GoodsBillets.RemoveAll(rec => rec.GoodsId == model.Id &&
		   !model.GoodsBillets.ContainsKey(rec.BilletsId));
			var updateBilletss = source.GoodsBillets.Where(rec => rec.GoodsId ==
		   model.Id && model.GoodsBillets.ContainsKey(rec.BilletsId));
			foreach (var updateBillets in updateBilletss)
			{
				updateBillets.Count =
			   model.GoodsBillets[updateBillets.BilletsId].Item2;
				model.GoodsBillets.Remove(updateBillets.BilletsId);
			}
			int maxPCId = source.GoodsBillets.Count > 0 ?
		   source.GoodsBillets.Max(rec => rec.Id) : 0;
			foreach (var pc in model.GoodsBillets)
			{
				source.GoodsBillets.Add(new GoodsBillets
				{
					Id = ++maxPCId,
					GoodsId = element.Id,
					BilletsId = pc.Key,
					Count = pc.Value.Item2
				});
			}
		}
		public void Delete(GoodsBindingModel model)
		{
			source.GoodsBillets.RemoveAll(rec => rec.GoodsId == model.Id);
			Goods element = source.Goodss.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				source.Goodss.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
		public List<GoodsViewModel> Read(GoodsBindingModel model)
		{
			return source.Goodss
			.Where(rec => model == null || rec.Id == model.Id)
			.Select(rec => new GoodsViewModel
			{
				Id = rec.Id,
				GoodsName = rec.GoodsName,
				Price = rec.Price,
				GoodsBillets = source.GoodsBillets
			.Where(recPC => recPC.GoodsId == rec.Id)
		   .ToDictionary(recPC => recPC.BilletsId, recPC =>
			(source.Billetss.FirstOrDefault(recC => recC.Id ==
		   recPC.BilletsId)?.BilletsName, recPC.Count))
			})
			.ToList();
		}
	}
}
