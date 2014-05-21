using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EF5Repository.Data.Models;

namespace EF5Repository.Data.Models.Mappings
{
    internal class CategoryMap : BaseEntityMap<Category>
    {
        public CategoryMap()
            : base()
        {
            ToTable("Category");

        }
    }
}
