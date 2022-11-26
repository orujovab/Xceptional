using IComp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Configurations
{
    public class HDDCapacityConfiguration : IEntityTypeConfiguration<HDDCapacity>
    {
        public void Configure(EntityTypeBuilder<HDDCapacity> builder)
        {
            builder.Property(x => x.Capacity).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CycleRate).IsRequired().HasMaxLength(100);
        }
    }
}
