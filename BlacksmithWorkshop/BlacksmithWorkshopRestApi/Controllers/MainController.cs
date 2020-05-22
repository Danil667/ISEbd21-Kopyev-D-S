using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlacksmithWorkshopBusinessLogic.BindingModels;
using BlacksmithWorkshopBusinessLogic.BusinessLogics;
using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopBusinessLogic.ViewModels;
using BlacksmithWorkshopRestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlacksmithWorkshopRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class MainController : ControllerBase
	{
		private readonly IOrderLogic _order;
		private readonly IGoodsLogic _snack;
		private readonly MainLogic _main;
		public MainController(IOrderLogic order, IGoodsLogic snack, MainLogic main)
		{
			_order = order;
			_snack = snack;
			_main = main;
		}
		[HttpGet]
		public List<GoodsModel> GetGoodsList() => _snack.Read(null)?.Select(rec =>
	  Convert(rec)).ToList();
		[HttpGet]
		public GoodsModel GetGoods(int GoodsId) => Convert(_snack.Read(new
	   GoodsBindingModel
		{ Id = GoodsId })?[0]);
		[HttpGet]
		public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
	   OrderBindingModel
		{ ClientId = clientId });
		[HttpPost]
		public void CreateOrder(CreateOrderBindingModel model) =>
	   _main.CreateOrder(model);
		private GoodsModel Convert(GoodsViewModel model)
		{
			if (model == null) return null;
			return new GoodsModel
			{
				Id = model.Id,
				GoodsName = model.GoodsName,
				Price = model.Price
			};
		}
	}
}