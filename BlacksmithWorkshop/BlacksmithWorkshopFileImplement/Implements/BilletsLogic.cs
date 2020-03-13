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
	public class BilletsLogic : IBilletsLogic
	{
		private readonly FileDataListSingleton source;
		public BilletsLogic()
		{
			source = FileDataListSingleton.GetInstance();
		}
		public void CreateOrUpdate(BilletsBindingModel model)
		{
			Billets element = source.Billetss.FirstOrDefault(rec => rec.BilletsName
		   == model.BilletsName && rec.Id != model.Id);
			if (element != null)
			{
				throw new Exception("Уже есть загототовка с таким названием");
			}
			if (model.Id.HasValue)
			{
				element = source.Billetss.FirstOrDefault(rec => rec.Id == model.Id);
				if (element == null)
				{
					throw new Exception("Элемент не найден");
				}
			}
			else
			{
				int maxId = source.Billetss.Count > 0 ? source.Billetss.Max(rec =>
			   rec.Id) : 0;
				element = new Billets { Id = maxId + 1 };
				source.Billetss.Add(element);
			}
			element.BilletsName = model.BilletsName;
		}
		public void Delete(BilletsBindingModel model)
		{
			Billets element = source.Billetss.FirstOrDefault(rec => rec.Id ==
		   model.Id);
			if (element != null)
			{
				source.Billetss.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
		public List<BilletsViewModel> Read(BilletsBindingModel model)
		{
			return source.Billetss
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
