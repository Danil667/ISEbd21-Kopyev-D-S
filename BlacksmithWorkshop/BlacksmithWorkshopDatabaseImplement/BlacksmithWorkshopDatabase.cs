using BlacksmithWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlacksmithWorkshopDatabaseImplement
{
	public class BlacksmithWorkshopDatabase : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-8MB9FIAG\SQLEXPRESS;Initial Catalog=BlacksmithWorkshopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
			}
			base.OnConfiguring(optionsBuilder);
		}
		public virtual DbSet<Billets> Billetss { set; get; }
		public virtual DbSet<Goods> Goodss { set; get; }
		public virtual DbSet<GoodsBillets> GoodsBilletss { set; get; }
		public virtual DbSet<Order> Orders { set; get; }
		public virtual DbSet<Client> Clients { set; get; }
		public virtual DbSet<Implementer> Implementers { set; get; }
	}
}
