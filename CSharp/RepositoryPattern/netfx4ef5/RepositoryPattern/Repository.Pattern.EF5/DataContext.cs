using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;

using Repository.Pattern.DataContext;
using Repository.Pattern.Infrastructure;


namespace Repository.Pattern.EF5
{
    public class DataContext : DbContext, IDataContext
    {
        #region Private Fields
        private readonly Guid _instanceId;
        #endregion Private Fields

        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public Guid InstanceId { get { return _instanceId; } }

        public override int SaveChanges()
        {
            SyncObjectsStatePreCommit();

            //var entityList = ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified);
            //foreach (var entity in entityList)
            //{
            //    if (entity.State == EntityState.Added)
            //    {
                   
            //    }
            //}

            var changes = base.SaveChanges();
            SyncObjectsStatePostCommit();
            return changes;
        }

        public void SyncObjectState(object entity)
        {
            Entry(entity).State = StateHelper.ConvertState(((IObjectState)entity).ObjectState);
        }

        public new DbSet<T> Set<T>() where T : class { return base.Set<T>(); }

        private void SyncObjectsStatePreCommit()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                dbEntityEntry.State = StateHelper.ConvertState(((IObjectState)dbEntityEntry.Entity).ObjectState);
            }
        }

        public void SyncObjectsStatePostCommit()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                ((IObjectState)dbEntityEntry.Entity).ObjectState = StateHelper.ConvertState(dbEntityEntry.State);
            }
        }

    }
}
