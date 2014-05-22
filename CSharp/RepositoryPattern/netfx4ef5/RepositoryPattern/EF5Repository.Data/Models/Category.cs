using System;
using System.Collections.Generic;
using Repository.Pattern.EF5;

namespace EF5Repository.Data.Models
{
    public partial class Category : EntityBase
    {
        public Category() { }

        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
