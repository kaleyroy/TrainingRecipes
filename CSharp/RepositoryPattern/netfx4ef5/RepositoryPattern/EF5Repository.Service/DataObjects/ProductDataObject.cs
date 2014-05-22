using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Service.DataObjects
{
    public class ProductDataObject : DataObject
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }

        public CategoryDataObject Category { get; set; }
    }
}
