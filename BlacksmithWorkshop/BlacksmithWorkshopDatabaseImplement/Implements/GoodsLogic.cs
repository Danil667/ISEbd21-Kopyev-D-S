using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
	public class GoodsLogic : IGoodsLogic
	{
		public void CreateOrUpdate(GoodsBindingModel model)
		{
			using (var context = new BlacksmithWorkshopDatabase())
			{
				using (var transaction = context.Database.BeginTransaction())
				{
					try
					{
						Goods element = context.Goodss.FirstOrDefault(rec =>
					   rec.GoodsName == model.GoodsName && rec.Id != model.Id);
						if (element != null)
						{
							throw new Exception("Уже есть изделие с таким названием");
						}
						if (model.Id.HasValue)
						{
							element = context.Goodss.FirstOrDefault(rec => rec.Id ==
						   model.Id);
							if (element == null)
							{
								throw new Exception("Элемент не найден");
							}
						}
						else
						{
							element = new Goods();
							context.Goodss.Add(element);
						}
						element.GoodsName = model.GoodsName;
						element.Price = model.Price;
						context.SaveChanges();
						if (model.Id.HasValue)
						{
							var GoodsBilletss = context.GoodsBilletss.Where(rec
						   => rec.GoodsId == model.Id.Value).ToList();
							// удалили те, которых нет в модели
							context.GoodsBilletss.RemoveRange(GoodsBilletss.Where(rec =>
							!model.GoodsBilletss.ContainsKey(rec.BilletsId)).ToList());
							context.SaveChanges();
							// обновили количество у существующих записей
							foreach (var updateBillets in GoodsBilletss)
							{
								updateBillets.Count =
							   model.GoodsBilletss[updateBillets.BilletsId].Item2;

								model.GoodsBilletss.Remove(updateBillets.BilletsId);
							}
							context.SaveChanges();
						}
						// добавили новые
						foreach (var pc in model.GoodsBilletss)
						{
							context.GoodsBilletss.Add(new GoodsBillets
							{
								GoodsId = element.Id,
								BilletsId = pc.Key,
								Count = pc.Value.Item2
							});
							context.SaveChanges();
						}
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
		}
		public void Delete(GoodsBindingModel model)
		{
			using (var context = new BlacksmithWorkshopDatabase())
			{
				using (var transaction = context.Database.BeginTransaction())
				{
					try
					{
						// удаяем записи по компонентам при удалении изделия
						context.GoodsBilletss.RemoveRange(context.GoodsBilletss.Where(rec => rec.GoodsId == model.Id));
						Goods element = context.Goodss.FirstOrDefault(rec => rec.Id
						== model.Id);
						if (element != null)
						{
							context.Goodss.Remove(element);
							context.SaveChanges();
						}
						else
						{
							throw new Exception("Элемент не найден");
						}
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
		}
		public List<GoodsViewModel> Read(GoodsBindingModel model)
		{
			using (var context = new BlacksmithWorkshopDatabase())
			{
				return context.Goodss
				.Where(rec => model == null || rec.Id == model.Id)
				.ToList()
			   .Select(rec => new GoodsViewModel
			   {
				   Id = rec.Id,
				   GoodsName = rec.GoodsName,
				   Price = rec.Price,
				   GoodsBilletss = context.GoodsBilletss
				.Include(recPC => recPC.Goods)
			   .Where(recPC => recPC.GoodsId == rec.Id)
			   .ToDictionary(recPC => recPC.GoodsId, recPC =>
				(recPC.Goods?.GoodsName, recPC.Count))
			   })
			   .ToList();
			}
		}
	}
}
