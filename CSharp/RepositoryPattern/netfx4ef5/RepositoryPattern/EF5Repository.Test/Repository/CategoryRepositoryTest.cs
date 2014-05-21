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
    public class CategoryRepositoryTest
    {
        [TestMethod]
        public void AddCategoryTest()
        {
            using (var unitOfWork = UnitOfWorkScope.BeginScope<ModelDataContext>())
            {
                Category category = new Category()
                {
                    ID = Guid.NewGuid(),
                    CategoryName = "Food",
                    Description = "Some remark"
                };

                var categoryRepository = unitOfWork.Repository<Category>();

                categoryRepository.Insert(category);
                unitOfWork.SaveChanges();

                Assert.IsTrue(true);
            }
        }
    }
}
