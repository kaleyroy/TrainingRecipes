using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Data.Models.Mappings
{
    internal class OrderMap : BaseEntityMap<Order>
    {
        public OrderMap()
            : base()
        {
            this.ToTable("Order");

            this.HasOptional(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);
        }
    }
}
