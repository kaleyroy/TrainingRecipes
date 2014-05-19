using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repository.Pattern.Repositories;
using Repository.Pattern.Infrastructure;

namespace EF5Repository.Data
{
    public abstract class RepositoryService<TEntity> where TEntity : IObjectState
    {
        public IRepository<TEntity> _repository;

        public RepositoryService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
    }
}
