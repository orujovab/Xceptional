using IComp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Configurations
{
    public class ProcessorConfiguration : IEntityTypeConfiguration<Processor>
    {

        public void Configure(EntityTypeBuilder<Processor> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsAvailable).HasDefaultValue(false);
            builder.Property(x => x.Speed).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CoreCount).IsRequired();
        }
    }
}
