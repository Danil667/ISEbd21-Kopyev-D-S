using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopListImplement.Implements
{
	public class GoodsLogic : IGoodsLogic
	{
		private readonly DataListSingleton source;
		public GoodsLogic()
		{
			source = DataListSingleton.GetInstance();
		}
		public void CreateOrUpdate(GoodsBindingModel model)
		{
			Goods tempGoods = model.Id.HasValue ? null : new Goods { Id = 1 };
			foreach (var goods in source.Goods)
			{
				if (goods.GoodsName == model.GoodsName && goods.Id != model.Id)
				{
					throw new Exception("Уже есть изделие с таким названием");
				}
				if (!model.Id.HasValue && goods.Id >= tempGoods.Id)
				{
					tempGoods.Id = goods.Id + 1;
				}
				else if (model.Id.HasValue && goods.Id == model.Id)
				{
					tempGoods = goods;
				}
			}
			if (model.Id.HasValue)
			{
			if (tempGoods == null)
				{
					throw new Exception("Элемент не найден");
				}
				CreateModel(model, tempGoods);
			}
			else
			{
				source.Goods.Add(CreateModel(model, tempGoods));
			}
		}
		public void Delete(GoodsBindingModel model)
		{
			// удаляем записи по компонентам при удалении изделия
			for (int i = 0; i < source.GoodsBillets.Count; ++i)
			{
				if (source.GoodsBillets[i].GoodsId == model.Id)
				{
					source.GoodsBillets.RemoveAt(i--);
				}
			}
			for (int i = 0; i < source.Goods.Count; ++i)
			{
				if (source.Goods[i].Id == model.Id)
				{
					source.Goods.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		private Goods CreateModel(GoodsBindingModel model, Goods goods)
		{
			goods.GoodsName = model.GoodsName;
			goods.Price = model.Price;
			//обновляем существуюущие компоненты и ищем максимальный идентификатор
			int maxPCId = 0;
			for (int i = 0; i < source.GoodsBillets.Count; ++i)
			{
				if (source.GoodsBillets[i].Id > maxPCId)
				{
					maxPCId = source.GoodsBillets[i].Id;
				}
				if (source.GoodsBillets[i].GoodsId == goods.Id)
				{
					// если в модели пришла запись компонента с таким id
					if (model.GoodsBilletss.ContainsKey(source.GoodsBillets[i].BilletsId))
					{
						// обновляем количество
						source.GoodsBillets[i].Count = model.GoodsBilletss[source.GoodsBillets[i].BilletsId].Item2;
						// из модели убираем эту запись, чтобы остались только не просмотренные
						model.GoodsBilletss.Remove(source.GoodsBillets[i].BilletsId);
					}
					else
					{
						source.GoodsBillets.RemoveAt(i--);
					}
				}
			}
			// новые записи
			foreach (var pc in model.GoodsBilletss)
			{
				source.GoodsBillets.Add(new GoodsBillets
				{
					Id = ++maxPCId,
					GoodsId = goods.Id,
					BilletsId = pc.Key,
					Count = pc.Value.Item2
				});
			}
			return goods;
		}
		public List<GoodsViewModel> Read(GoodsBindingModel model)
		{
			List<GoodsViewModel> result = new List<GoodsViewModel>();
			foreach (var billets in source.Goods)
			{
				if (model != null)
				{
					if (billets.Id == model.Id)
					{
						result.Add(CreateViewModel(billets));
						break;
					}
					continue;
				}
				result.Add(CreateViewModel(billets));
			}
			return result;
		}
		private GoodsViewModel CreateViewModel(Goods goods)
		{
			Dictionary<int, (string, int)> goodsBillets = new Dictionary<int,
	(string, int)>();
			foreach (var pc in source.GoodsBillets)
			{
				if (pc.GoodsId == goods.Id)
				{
					string BilletsName = string.Empty;
					foreach (var Billets in source.Billets)
					{
						if (pc.BilletsId == Billets.Id)
						{
							BilletsName = Billets.BilletsName;
							break;
						}
					}
					goodsBillets.Add(pc.BilletsId, (BilletsName, pc.Count));
				}
			}
			return new GoodsViewModel
			{
				Id = goods.Id,
				GoodsName = goods.GoodsName,
				Price = goods.Price,
				GoodsBilletss = goodsBillets
			};
		}
	}
}
