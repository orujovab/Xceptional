using IComp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Configurations
{
    public class VideoCardConfiguration : IEntityTypeConfiguration<VideoCard>
    {
        public void Configure(EntityTypeBuilder<VideoCard> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModelName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsAvailable).HasDefaultValue(false);
            builder.Property(x => x.CoreSpeed).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MemoryCapacity).HasMaxLength(100).IsRequired();
        }
    }
}
