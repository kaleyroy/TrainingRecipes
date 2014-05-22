using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Data.Models.Mappings
{
    internal class OrderMap : EntityMapBase<Order>
    {
        public OrderMap()
            : base()
        {
            ToTable("Order");

            HasOptional(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);
        }
    }
}
