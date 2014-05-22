using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Data.Models.Mappings
{
    internal class CustomerMap : EntityMapBase<Customer>
    {
        public CustomerMap()
            : base()
        {
            ToTable("Customer");
        }
    }
}
