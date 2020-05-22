using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement
{
	public class DataListSingleton
	{
		private static DataListSingleton instance;
		public List<Billets> Billets { get; set; }
		public List<Order> Orders { get; set; }
		public List<Goods> Goods { get; set; }
		public List<GoodsBillets> GoodsBilletss { get; set; }
		public List<Client> Clients { get; set; }
		public List<Implementer> Implementers { get; set; }
		private DataListSingleton()
		{
			Billets = new List<Billets>();
			Orders = new List<Order>();
			Goods = new List<Goods>();
			GoodsBilletss = new List<GoodsBillets>();
			Clients = new List<Client>();
			Implementers = new List<Implementer>();
		}
		public static DataListSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new DataListSingleton();
			}
			return instance;
		}
	}
}
