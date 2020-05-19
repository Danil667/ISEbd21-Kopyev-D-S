using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.HelperModels;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogics
{
	public class ReportLogic
	{
		private readonly IBilletsLogic billetsLogic;
		private readonly IGoodsLogic goodsLogic;
		private readonly IOrderLogic orderLogic;
		public ReportLogic(IGoodsLogic goodsLogic, IBilletsLogic billetsLogic, IOrderLogic orderLogic)
		{
			this.goodsLogic = goodsLogic;
			this.billetsLogic = billetsLogic;
			this.orderLogic = orderLogic;
		}

		/// <summary>
		/// Получение списка компонент с указанием, в каких изделиях используются
		/// </summary>
		/// <returns></returns>
		public List<ReportGoodsBilletsViewModel> GetGoodsBillets()
		{
			var goodss = goodsLogic.Read(null);
			var list = new List<ReportGoodsBilletsViewModel>();
			foreach (var goods in goodss)
			{
				foreach (var gb in goods.GoodsBilletss)
				{
					var record = new ReportGoodsBilletsViewModel
					{
						GoodsName = goods.GoodsName,
						BilletsName = gb.Value.Item1,
						Count = gb.Value.Item2
					};
					list.Add(record);
				}
			}
			return list;
		}
		/// <summary>
		/// Получение списка заказов за определенный период
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
		{
			var list = orderLogic
			.Read(new OrderBindingModel
			{
				DateFrom = model.DateFrom,
				DateTo = model.DateTo
			})
			.GroupBy(rec => rec.DateCreate.Date)
			.OrderBy(recG => recG.Key)
			.ToList();

			return list;
		}
		/// <summary>
		/// Сохранение компонент в файл-Word
		/// </summary>
		/// <param name="model"></param>
		public void SaveGoodssToWordFile(ReportBindingModel model)
		{
			SaveToWord.CreateDoc(new WordInfo
			{
				FileName = model.FileName,
				Title = "Список товаров",
				Goodss = goodsLogic.Read(null)
			});
		}
		/// <summary>
		/// Сохранение компонент с указаеним продуктов в файл-Excel
		/// </summary>
		/// <param name="model"></param>
		public void SaveGoodsBilletsToExcelFile(ReportBindingModel model)
		{
			SaveToExcel.CreateDoc(new ExcelInfo
			{
				FileName = model.FileName,
				Title = "Список заказов",
				Orders = GetOrders(model)
			});
		}
		/// <summary>
		/// Сохранение заказов в файл-Pdf
		/// </summary>
		/// <param name="model"></param>
		public void SaveGoodsToPdfFile(ReportBindingModel model)
		{
			SaveToPdf.CreateDoc(new PdfInfo
			{
				FileName = model.FileName,
				Title = "Список товаров по заготовкам",
				GoodsBilletss = GetGoodsBillets(),
			});
		}
	}
}
