using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Service.DataObjects
{
    public class OrderDataObject : BaseDataObject
    {
        public DateTime OrderDate { get; set; }

        public decimal TotalCost
        {
            get
            {
                decimal total = 0;

                if (this.OrderDetails != null)
                {
                    this.OrderDetails.ForEach(d => total += d.UnitPrice * d.Quantity );
                }

                return total;
            }
        }

        public CustomerDataObject Customer { get; set; }
        public List<OrderDetailDataObject> OrderDetails { get; set; }
    }
}
