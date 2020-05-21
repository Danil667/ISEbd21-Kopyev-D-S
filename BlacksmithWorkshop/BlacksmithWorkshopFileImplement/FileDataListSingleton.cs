using BlacksmithWorkshopBusinessLogic.Enums;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BlacksmithWorkshopFileImplement
{
	public class FileDataListSingleton
	{
		private static FileDataListSingleton instance;
		private readonly string BilletsFileName = "C:\\Users\\Admin\\Documents\\BlacksmithWorkshop\\Billets.xml";
		private readonly string OrderFileName = "C:\\Users\\Admin\\Documents\\BlacksmithWorkshop\\Order.xml";
		private readonly string GoodsFileName = "C:\\Users\\Admin\\Documents\\BlacksmithWorkshop\\Goods.xml";
		private readonly string ClientFileName = "C:\\Users\\Admin\\Documents\\BlacksmithWorkshop\\Client.xml";
		private readonly string GoodsBilletsFileName = "C:\\Users\\Admin\\Documents\\BlacksmithWorkshop\\GoodsBillets.xml";
		public List<Billets> Billetss { get; set; }
		public List<Order> Orders { get; set; }
		public List<Goods> Goodss { get; set; }
		public List<GoodsBillets> GoodsBillets { get; set; }
		public List<Client> Clients { get; set; }
		private FileDataListSingleton()
		{
			Billetss = LoadBillets();
			Orders = LoadOrders();
			Goodss = LoadGoods();
			GoodsBillets = LoadGoodsBillets();
			Clients = LoadClients();
		}
		public static FileDataListSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new FileDataListSingleton();
			}
			return instance;
		}
		~FileDataListSingleton()
		{
			SaveBillets();
			SaveOrders();
			SaveGoods();
			SaveGoodsBillets();
			SaveClients();
		}
		private List<Client> LoadClients()
		{
			var list = new List<Client>();
			if (File.Exists(ClientFileName))
			{
				XDocument xDocument = XDocument.Load(ClientFileName);
				var xElements = xDocument.Root.Elements("Client").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Client
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ClientFIO = elem.Element("ClientFIO").Value,
						Email = elem.Element("Email").Value,
						Password = elem.Element("Password").Value
					});
				}
			}
			return list;
		}
		private List<Billets> LoadBillets()
		{
			var list = new List<Billets>();
			if (File.Exists(BilletsFileName))
			{
				XDocument xDocument = XDocument.Load(BilletsFileName);
				var xElements = xDocument.Root.Elements("Billets").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Billets
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						BilletsName = elem.Element("BilletsName").Value
					});
				}
			}
			return list;
		}
		private List<Order> LoadOrders()
		{
			var list = new List<Order>();
			if (File.Exists(OrderFileName))
			{
				XDocument xDocument = XDocument.Load(OrderFileName);
				var xElements = xDocument.Root.Elements("Order").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Order
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						GoodsId = Convert.ToInt32(elem.Element("GoodsId").Value),
						Count = Convert.ToInt32(elem.Element("Count").Value),
						Sum = Convert.ToDecimal(elem.Element("Sum").Value),
						ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
						Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
				   elem.Element("Status").Value),
						DateCreate =
				   Convert.ToDateTime(elem.Element("DateCreate").Value),
						DateImplement =
				   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
				   Convert.ToDateTime(elem.Element("DateImplement").Value),
					});
				}
			}
			return list;
		}
		private List<Goods> LoadGoods()
		{
			var list = new List<Goods>();
			if (File.Exists(GoodsFileName))
			{
				XDocument xDocument = XDocument.Load(GoodsFileName);
				var xElements = xDocument.Root.Elements("Goods").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Goods
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						GoodsName = elem.Element("GoodsName").Value,
						Price = Convert.ToDecimal(elem.Element("Price").Value)
					});
				}
			}
			return list;
		}
		private void SaveClients()
		{
			if (Clients != null)
			{
				var xElement = new XElement("Clients");

				foreach (var client in Clients)
				{
					xElement.Add(new XElement("Client",
					new XAttribute("Id", client.Id),
					new XElement("ClientFIO", client.ClientFIO),
					new XElement("Email", client.Email),
					new XElement("Password", client.Password)));
				}

				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(ClientFileName);
			}
		}
		private List<GoodsBillets> LoadGoodsBillets()
		{
			var list = new List<GoodsBillets>();
			if (File.Exists(GoodsBilletsFileName))
			{
				XDocument xDocument = XDocument.Load(GoodsBilletsFileName);
				var xElements = xDocument.Root.Elements("GoodsBillets").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new GoodsBillets
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						GoodsId = Convert.ToInt32(elem.Element("GoodsId").Value),
						BilletsId = Convert.ToInt32(elem.Element("BilletsId").Value),
						Count = Convert.ToInt32(elem.Element("Count").Value)
					});
				}
			}
			return list;
		}
		private void SaveBillets()
		{
			if (Billetss != null)
			{
				var xElement = new XElement("Billetss");
				foreach (var Billets in Billetss)
				{
					xElement.Add(new XElement("Billets",
					new XAttribute("Id", Billets.Id),
					new XElement("BilletsName", Billets.BilletsName)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(BilletsFileName);
			}
		}
		private void SaveOrders()
		{
			if (Orders != null)
			{
				var xElement = new XElement("Orders");
				foreach (var order in Orders)
				{
					xElement.Add(new XElement("Order",
					new XAttribute("Id", order.Id),
					new XElement("GoodsId", order.GoodsId),
					new XElement("ClientId", order.ClientId),
					new XElement("Count", order.Count),
					new XElement("Sum", order.Sum),
					new XElement("Status", order.Status),
					new XElement("DateCreate", order.DateCreate),
					new XElement("DateImplement", order.DateImplement)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(OrderFileName);
			}
		}
		private void SaveGoods()
		{
			if (Goodss != null)
			{
				var xElement = new XElement("Goodss");
				foreach (var Goods in Goodss)
				{
					xElement.Add(new XElement("Goods",
					new XAttribute("Id", Goods.Id),
					new XElement("GoodsName", Goods.GoodsName),
					new XElement("Price", Goods.Price)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(GoodsFileName);
			}
		}
		private void SaveGoodsBillets()
		{
			if (GoodsBillets != null)
			{
				var xElement = new XElement("GoodsBillets");
				foreach (var GoodsBillets in GoodsBillets)
				{
					xElement.Add(new XElement("GoodsBillets",
					new XAttribute("Id", GoodsBillets.Id),
					new XElement("GoodsId", GoodsBillets.GoodsId),
					new XElement("BilletsId", GoodsBillets.BilletsId),
					new XElement("Count", GoodsBillets.Count)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(GoodsBilletsFileName);
			}
		}
	}
}
