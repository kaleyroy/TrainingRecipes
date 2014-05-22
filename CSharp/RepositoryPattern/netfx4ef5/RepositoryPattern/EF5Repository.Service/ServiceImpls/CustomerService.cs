using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using EF5Repository.Data.Models;
using EF5Repository.Data.Repositories;
using EF5Repository.Service.DataObjects;

namespace EF5Repository.Service.ServiceImpls
{
    public class CustomerService : UnitOfWorkService,ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> customerRepository)
            : base(unitOfWork)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerDataObject> Add(IEnumerable<CustomerDataObject> customers)
        {
            return PerformCreateObjects<CustomerDataObject, Customer>(customers, _customerRepository);
        }

        public IEnumerable<CustomerDataObject> Update(IEnumerable<CustomerDataObject> customers)
        {
            return PerformApplyObjects<CustomerDataObject, Customer>(customers, _customerRepository);
        }

        public void Remove(IEnumerable<CustomerDataObject> customers)
        {
            PerformRemoveObjects<CustomerDataObject, Customer>(customers, _customerRepository);
        }

        public IEnumerable<CustomerDataObject> GetByRegion(string customerRegion)
        {
            var customers = _customerRepository.SelectByRegion(customerRegion);

            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDataObject>>(customers.ToList());
        }

        public PaginationDataObject<CustomerDataObject> GetByRegionWithPagination(string customerRegion)
        {
            throw new NotImplementedException();
        }
    }
}
