using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Service.DataObjects
{
    public class OrderDetailDataObject : BaseDataObject
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public Guid ProductID { get; set; }
        public ProductDataObject Product { get; set; }

        public Guid OrderID { get; set; }
        public OrderDataObject Order { get; set; }
    }
}
