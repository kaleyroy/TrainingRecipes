using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;

using Repository.Pattern.Repositories;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.EF5;

namespace EF5Repository.Data.Repositories
{
    public static class RepositoryExtension
    {
        public static void ApplyChanges(this IRepository<EntityBase> repository, EntityBase entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var dbContext = (repository as IEFRepository<EntityBase>).Context;

            if (dbContext.Entry<EntityBase>(entity).State == EntityState.Detached)
            {
                var attachedEntity = dbContext.Set<EntityBase>().Find(entity.ID);
                if (attachedEntity == null)
                    throw new ArgumentNullException("attachedEntity");

                var attachedEntry = dbContext.Entry<EntityBase>(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);

                entity.ObjectState = ObjectState.Modified;
            }
        }


    }
}
