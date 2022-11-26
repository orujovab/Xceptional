using IComp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.IsAvailable).HasDefaultValue(false);
            builder.Property(x => x.IsNew).HasDefaultValue(false);
            builder.Property(x => x.IsFeatured).HasDefaultValue(false);
            builder.Property(x => x.IsPopular).HasDefaultValue(false);
            builder.Property(x => x.HasBluetooth).HasDefaultValue(false);
            builder.Property(x => x.HasWifi).HasDefaultValue(false);
            builder.Property(x => x.CostPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.SalePrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DiscountPercent).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Rate).IsRequired(false);
            
        }
    }
}
