using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Pattern.EF5
{
    public sealed class QueryObjectSpec<TEntity> : QueryObject<TEntity>
    {
        public QueryObjectSpec(Expression<Func<TEntity, bool>> predicate)
        {
            this.Add(predicate);
        }
    }
}
