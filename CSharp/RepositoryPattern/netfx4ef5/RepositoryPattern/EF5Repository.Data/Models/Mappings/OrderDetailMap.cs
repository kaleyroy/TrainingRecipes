using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Data.Models.Mappings
{
    internal class OrderDetailMap : BaseEntityMap<OrderDetail>
    {
        public OrderDetailMap()
            : base()
        {
            this.ToTable("OrderDetail");

            this.HasOptional(d => d.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(d => d.OrderID);
            this.HasOptional(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductID);
        }
    }
}
