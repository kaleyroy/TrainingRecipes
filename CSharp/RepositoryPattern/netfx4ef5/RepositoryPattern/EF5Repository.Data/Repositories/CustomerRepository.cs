using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EF5Repository.Data.Models;
using EF5Repository.Data.Queries;
using Repository.Pattern.Repositories;

namespace EF5Repository.Data.Repositories
{
    public static class CustomerRepository
    {
        public static IEnumerable<Customer> SelectByRegion(this IRepository<Customer> repository, string region)
        {
            return repository.Queryable()
                            .Where(c => c.Region.Equals(region))
                            .AsEnumerable();
        }

        public static PagedResult<Customer> SelectByRegionWithPagination(this IRepository<Customer> repository, string region,int page = 1,int pageSize = 5)
        {
            var totalRecords = 0;

            var pagedData = repository.Query(c => c.Region.Equals(region))
                             .OrderBy(q => q.OrderBy(c => c.Region))
                             .SelectPage(page, pageSize, out totalRecords)
                             .AsEnumerable();

            return new PagedResult<Customer>(totalRecords, pageSize, page, pagedData);
        }

        public static IEnumerable<Customer> SelectByRegionAndCity(this IRepository<Customer> repository, string region, string city)
        {
            return repository.Query(CustomerQuery.LivesIn(city, region))
                             .Select().AsEnumerable();
                             
        }
    }
}
