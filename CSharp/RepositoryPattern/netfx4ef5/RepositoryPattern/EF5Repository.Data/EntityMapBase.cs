using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF5Repository.Data
{
    public class EntityMapBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public EntityMapBase()
        {
            HasKey(e => e.ID);
            Property(e => e.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
