using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.EF5;
using EF5Repository.Data;
using EF5Repository.Data.Models;
using EF5Repository.Data.Repositories;

namespace EF5Repository.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            using(var dataContext = new ModelDataContext())
            using (var unitOfWork = new UnitOfWork(dataContext) )
            {
                var customerID = Guid.NewGuid();

                var customer = new Customer()
                {
                     ID = Guid.NewGuid(),
                     CompanyName = "BBC",
                     ContactName = "BBC Contact",
                     ContactTitle = "BBC Partner Contact",
                     Address = "No.1 Bee Street",
                     City = "London",
                     Country = "UK",
                     Region = "AA",
                     Fax = "000000",
                     Phone = "00000000000",
                     PostalCode = "555555"
                };

                var customerRepository = unitOfWork.Repository<Customer>();
                
                customerRepository.Insert(customer); ;                
                unitOfWork.SaveChanges();

                var insertedCustomer = customerRepository.Find(customerID);
                
                Assert.IsNotNull(insertedCustomer);
                Assert.AreEqual(customerID, insertedCustomer.ID);
            }
        }

        [TestMethod]
        public void GetCustomerTest()
        {
            using (var dataContext = new ModelDataContext())
            using (var unitOfWork = new UnitOfWork(dataContext))
            {
                var customerID = Guid.Parse("46de4e9f-564f-4273-bbd1-45bed3166668");

                var customerRepository = unitOfWork.Repository<Customer>();
                var insertedCustomer = customerRepository.Find(customerID);

                Assert.IsNotNull(insertedCustomer);
                Assert.AreEqual(customerID, insertedCustomer.ID);
            }
        }

        [TestMethod]
        public void QueryCustomersByRegionTest()
        {
            using (var dataContext = new ModelDataContext())
            using (var unitOfWork = new UnitOfWork(dataContext))
            {
                var customerRegion = "AA";

                var customerRepository = unitOfWork.Repository<Customer>();
                var customers = customerRepository.QueryByRegion(customerRegion);

                Assert.AreEqual(3, customers.Count());
            }
        }

        [TestMethod]
        public void QueryCustomersByRegionWithPaginationTest()
        {
            using (var dataContext = new ModelDataContext())
            using (var unitOfWork = new UnitOfWork(dataContext))
            {
                var customerRegion = "AA";

                var customerRepository = unitOfWork.Repository<Customer>();
                var pageCustomers = customerRepository.QueryByRegionWithPagination(customerRegion);

                Assert.AreEqual(3, pageCustomers.PagedData.Count());
            }
        }

        [TestMethod]
        public void QueryByRegionAndCityTest()
        {
            var customerRegion = "AA";
            var customerCity = "London";

            using (var dataContext = new ModelDataContext())
            using (var unitOfWork = new UnitOfWork(dataContext))
            {

                var customerRepository = unitOfWork.Repository<Customer>();

                var customers = customerRepository.QueryByRegionAndCity(customerRegion, customerCity);

                Assert.AreEqual(3, customers.ToList().Count);

            }
        }
    }
}
