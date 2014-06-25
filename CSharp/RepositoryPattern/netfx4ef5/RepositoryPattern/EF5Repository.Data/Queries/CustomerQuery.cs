using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repository.Pattern.EF5;
using EF5Repository.Data.Models;

namespace EF5Repository.Data.Queries
{
    public static class CustomerQuery
    {
        //public CustomerQuery ByRegion(string region)
        //{
        //    Add(c => c.Region.Equals(region));

        //    return this;
        //}

        //public CustomerQuery ByCity(string city)
        //{
        //    And(c => c.City.Equals(city));

        //    return this;
        //}

        public static QueryObject<Customer> LivesInRegion(string region)
        {
           return new QueryObjectSpec<Customer>(c => c.Region.Equals(region));
        }

        public static QueryObject<Customer> LivesInCity(string city)
        {
            return new QueryObjectSpec<Customer>(c => c.City.Equals(city));
        }

        public static QueryObject<Customer> LivesIn(string city, string region)
        {
            return new QueryObjectSpec<Customer>(LivesInCity(city).And(LivesInRegion(region)));
        }
    }
}
