using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AutoMapper;
using Repository.Pattern.EF5;
using Repository.Pattern.Repositories;
using EF5Repository.Data;
using EF5Repository.Data.Models;
using EF5Repository.Service;
using EF5Repository.Service.DataObjects;
using EF5Repository.Service.Profiles;
using EF5Repository.Service.ServiceImpls;

namespace EF5Repository.Test.Service
{
    [TestClass]
    public class CustomerServiceTest
    {
        [TestInitialize]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
                cfg.AddProfile(new ProductProfile());
                cfg.AddProfile(new OrderProfile());

            });
        }

        [TestMethod]
        public void AddCustomerObjectsTest()
        {
            var customer = new CustomerDataObject()
            {
                ID = Guid.NewGuid(),
                Name = "New",
                Region = "BBT",
                Country = "BeiJing"
            };

            using (var unitOfWork = UnitOfWorkScope.BeginScope<ModelDataContext>())
            {
                var customerService = new CustomerService(unitOfWork);
                customerService.Add(new List<CustomerDataObject>() { customer });
            }
        }

        [TestMethod]
        public void UpdateCustomerObjects()
        {
            var id = Guid.Parse("3d86d1d0-e875-4764-9ee6-7e5835d0e921");

            using (var unitOfWork = UnitOfWorkScope.BeginScope<ModelDataContext>())
            {
                var customerService = new CustomerService(unitOfWork);

                var customer = customerService.GetByID(id);
                customer.Country = "CN";

                customerService.Update(new List<CustomerDataObject>() { customer });
            }
        }
    }
}
