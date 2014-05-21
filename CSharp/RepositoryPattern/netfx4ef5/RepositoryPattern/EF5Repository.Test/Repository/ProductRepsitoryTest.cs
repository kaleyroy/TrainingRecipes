using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.EF5;
using EF5Repository.Data;
using EF5Repository.Data.Models;
using EF5Repository.Data.Repositories;

namespace EF5Repository.Test.Repository
{
    [TestClass]
    public class ProductRepsitoryTest
    {
        [TestMethod]
        public void AddProductTest()
        {
            Guid categoryId = Guid.Parse("400a913b-ae54-4b01-a0c4-9db23355b9ab");

            using (var unitOfWork = UnitOfWorkScope.BeginScope<ModelDataContext>())
            {
                var productRepoistory = unitOfWork.Repository<Product>();

                Product product = new Product()
                {
                    ID = Guid.NewGuid(),
                    ProductName = "Sawithc",
                    CategoryID = categoryId
                };

                productRepoistory.Insert(product);
                unitOfWork.SaveChanges();
            }

            Assert.IsTrue(true);
        }
    }
}
