using IComp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Configurations
{
    public class MemoryConfiguration : IEntityTypeConfiguration<ProdMemory>
    {
        public void Configure(EntityTypeBuilder<ProdMemory> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IsAvailable).HasDefaultValue(false);
            builder.Property(x => x.Speed).HasMaxLength(50).IsRequired();
            builder.Property(x => x.DDRType).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(x => x.Count).IsRequired();

        }
    }
}
