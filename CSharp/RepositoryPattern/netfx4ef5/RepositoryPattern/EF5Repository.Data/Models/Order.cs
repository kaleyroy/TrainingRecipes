using System;
using System.Collections.Generic;

namespace EF5Repository.Data.Models
{
    public partial class Order : BaseEntity
    {
        public Order(){ }
      
        public DateTime OrderDate { get; set; }

        public Guid? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
