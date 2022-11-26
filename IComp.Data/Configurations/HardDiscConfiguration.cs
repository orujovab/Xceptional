using IComp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Configurations
{
    public class HardDiscConfiguration : IEntityTypeConfiguration<HardDisc>
    {
        public void Configure(EntityTypeBuilder<HardDisc> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IsAvailable).HasDefaultValue(false);
            
        }
    }
}
