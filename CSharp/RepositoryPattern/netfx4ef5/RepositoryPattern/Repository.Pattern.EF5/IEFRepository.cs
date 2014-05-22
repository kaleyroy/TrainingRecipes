using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using Repository.Pattern.Repositories;
using Repository.Pattern.Infrastructure;

namespace Repository.Pattern.EF5
{
    public interface IEFRepository<TEntity> : IRepository<TEntity> where TEntity : IObjectState
    {
        DbContext Context { get; }
    }


}
