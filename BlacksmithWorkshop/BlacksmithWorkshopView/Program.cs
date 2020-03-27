﻿using BlacksmithWorkshopBusinessLogic.Interfaces;
using BlacksmithWorkshopDatabaseImplement.Implements;
using BlacksmithWorkshopBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace BlacksmithWorkshopView
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var container = BuildUnityContainer();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.Resolve<FormMain>());
		}
		private static IUnityContainer BuildUnityContainer()
		{
			var currentContainer = new UnityContainer();
			currentContainer.RegisterType<IGoodsLogic, GoodsLogic>(new
		   HierarchicalLifetimeManager());
			currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IBilletsLogic, BilletsLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
			return currentContainer;
		}
	}
}
