using IComp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Data.Configurations
{
    public class ProcessorSerieConfiguration : IEntityTypeConfiguration<ProcessorSerie>
    {
        public void Configure(EntityTypeBuilder<ProcessorSerie> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
