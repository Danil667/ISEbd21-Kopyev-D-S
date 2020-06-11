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
		public List<Billets> Billetss { get; set; }
		public List<Order> Orders { get; set; }
		public List<Goods> Goods { get; set; }
		public List<Storage> Storages { get; set; }
		public List<StorageBillets> StorageBilletss { get; set; }
		public List<GoodsBillets> GoodsBillets { get; set; }
		private DataListSingleton()
		{
			Billetss = new List<Billets>();
			Orders = new List<Order>();
			Goods = new List<Goods>();
			GoodsBillets = new List<GoodsBillets>();
			Storages = new List<Storage>();
			StorageBilletss = new List<StorageBillets>();
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
