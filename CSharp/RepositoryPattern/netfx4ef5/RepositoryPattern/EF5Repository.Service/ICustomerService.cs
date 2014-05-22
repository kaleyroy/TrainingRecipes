using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EF5Repository.Service.DataObjects;

namespace EF5Repository.Service
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDataObject> Add(IEnumerable<CustomerDataObject> customers);
        IEnumerable<CustomerDataObject> Update(IEnumerable<CustomerDataObject> customers);
        IEnumerable<CustomerDataObject> Remove(IEnumerable<CustomerDataObject> customers);

        CustomerDataObject GetByID(Guid id);
        IEnumerable<CustomerDataObject> GetByRegion(string customerRegion);
        PaginationDataObject<CustomerDataObject> GetByRegionWithPagination(string customerRegion);
    }
}
