using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using Repository.Pattern.EF5;
using EF5Repository.Data.Models;
using EF5Repository.Data.Models.Mappings;

namespace EF5Repository.Data
{
    public class ModelDataContext : DataContext
    {
        static ModelDataContext()
        {
            Database.SetInitializer<ModelDataContext>(null);
        }

        public ModelDataContext()
            : base("ModelDataContext")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
