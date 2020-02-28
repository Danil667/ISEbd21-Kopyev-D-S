using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopListImplement.Implements
{
	public class BilletsLogic : IBilletsLogic
	{
		private readonly DataListSingleton source;
		public BilletsLogic()
		{
			source = DataListSingleton.GetInstance();
		}
		public void CreateOrUpdate(BilletsBindingModel model)
		{
			Billets tempBillets = model.Id.HasValue ? null : new Billets { Id = 1 };
			foreach (var billets in source.Billets)
			{
				if (billets.BilletsName == model.BilletsName && billets.Id != model.Id)
				{
					throw new Exception("Уже есть компонент с таким названием");
				}
				if (!model.Id.HasValue && billets.Id >= tempBillets.Id)
				{
					tempBillets.Id = billets.Id + 1;
				}
				else if (model.Id.HasValue && billets.Id == model.Id)
				{
					tempBillets = billets;
				}
			}
			if (model.Id.HasValue)
			{
				if (tempBillets == null)
				{
					throw new Exception("Элемент не найден");
				}
				CreateModel(model, tempBillets);
			}
			else
			{
				source.Billets.Add(CreateModel(model, tempBillets));
			}
		}
		public void Delete(BilletsBindingModel model)
		{
			for (int i = 0; i < source.Billets.Count; ++i)
			{
				if (source.Billets[i].Id == model.Id.Value)
				{
					source.Billets.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		public List<BilletsViewModel> Read(BilletsBindingModel model)
		{
			List<BilletsViewModel> result = new List<BilletsViewModel>();
			foreach (var billets in source.Billets)
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
		private Billets CreateModel(BilletsBindingModel model, Billets billets)
		{
			billets.BilletsName = model.BilletsName;
			return billets;
		}
		private BilletsViewModel CreateViewModel(Billets billets)
		{
			return new BilletsViewModel
			{
				Id = billets.Id,
				BilletsName = billets.BilletsName
			};
		}
	}
}
