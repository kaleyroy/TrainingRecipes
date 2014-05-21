using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repository.Pattern.EF5;
using EF5Repository.Data.Models;

namespace EF5Repository.Data.Queries
{
    public class CustomerQuery : QueryObject<Customer>
    {
        public CustomerQuery ByRegion(string region)
        {
            Add(c => c.Region.Equals(region));

            return this;
        }

        public CustomerQuery ByCity(string city)
        {
            And(c => c.City.Equals(city));

            return this;
        }
    }
}
