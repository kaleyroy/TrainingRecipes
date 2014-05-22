using System;
using System.Collections.Generic;

namespace EF5Repository.Data.Models
{
    public partial class OrderDetail : EntityBase
    {  
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public Guid? OrderID { get; set; }
        public virtual Order Order { get; set; }

        public Guid? ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
