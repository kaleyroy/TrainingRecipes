using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Service.DataObjects
{
    public class OrderDataObject : DataObject
    {
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }

        public CustomerDataObject Customer { get; set; }
        public List<OrderDetailDataObject> OrderDetails { get; set; }
    }
}
