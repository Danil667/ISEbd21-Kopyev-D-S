using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
	public class BilletsLogic : IBilletsLogic
	{
		public void CreateOrUpdate(BilletsBindingModel model)
		{
			using (var context = new BlacksmithWorkshopDatabase())
			{
				Billets element = context.Billetss.FirstOrDefault(rec =>
			   rec.BilletsName == model.BilletsName && rec.Id != model.Id);
				if (element != null)
				{
					throw new Exception("Уже есть компонент с таким названием");
				}
				if (model.Id.HasValue)
				{
					element = context.Billetss.FirstOrDefault(rec => rec.Id ==
				   model.Id);
					if (element == null)
					{
						throw new Exception("Элемент не найден");
					}
				}
				else
				{
					element = new Billets();
					context.Billetss.Add(element);
				}
				element.BilletsName = model.BilletsName;
				context.SaveChanges();
			}
		}
		public void Delete(BilletsBindingModel model)
		{
			using (var context = new BlacksmithWorkshopDatabase())
			{
				Billets element = context.Billetss.FirstOrDefault(rec => rec.Id ==
			   model.Id);
				if (element != null)
				{
					context.Billetss.Remove(element);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("Элемент не найден");
				}
			}
		}
		public List<BilletsViewModel> Read(BilletsBindingModel model)
		{
			using (var context = new BlacksmithWorkshopDatabase())
			{
				return context.Billetss
				.Where(rec => model == null || rec.Id == model.Id)
				.Select(rec => new BilletsViewModel
				{
					Id = rec.Id,
					BilletsName = rec.BilletsName
				})
				.ToList();
			}
		}
	}
}
