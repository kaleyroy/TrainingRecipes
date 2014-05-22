using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Data.Models.Mappings
{
    internal class OrderDetailMap : EntityMapBase<OrderDetail>
    {
        public OrderDetailMap()
            : base()
        {
            ToTable("OrderDetail");

            HasOptional(d => d.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(d => d.OrderID);
            HasOptional(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductID);
        }
    }
}
