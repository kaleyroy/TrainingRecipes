using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Data.Models.Mappings
{
    internal class CustomerMap : BaseEntityMap<Customer>
    {
        public CustomerMap()
            : base()
        {
            this.ToTable("Customer");
        }
    }
}
