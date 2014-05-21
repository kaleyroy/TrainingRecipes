using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repository.Pattern.UnitOfWork;
using Repository.Pattern.DataContext;

namespace Repository.Pattern.EF5
{
    public static class UnitOfWorkScope
    {
        public static IUnitOfWork BeginScope<DataContext>() where DataContext : IDataContext,new()
        {
            return new UnitOfWork(new DataContext());
        }
    }
}
