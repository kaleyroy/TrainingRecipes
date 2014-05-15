﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Data.Models.Mappings
{
    internal class ProductMap : BaseEntityMap<Product>
    {
        public ProductMap()
            : base()
        {
            this.ToTable("Product");

            this.HasOptional(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);
            
        }
    }
}