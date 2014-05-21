using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Service.DataObjects
{
    public class CategoryDataObject : BaseDataObject
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public List<ProductDataObject> Products { get; set; }
    }
}
