using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts.Configurations
{
    public class FarmConfiguration : IEntityTypeConfiguration<Farm>
    {
        public void Configure(EntityTypeBuilder<Farm> builder)
        {
            builder.Property(h => h.Code).IsRequired().HasMaxLength(5);
            builder.Property(h => h.Name).IsRequired().HasMaxLength(100);
            builder.Property(h => h.Address).IsRequired().HasMaxLength(100);
            builder.Property(h => h.Phone).IsRequired().HasMaxLength(15);
            builder.HasIndex(ix => ix.Code).IsUnique();
            builder.HasData(new Farm { Id = 1, Code = "ARZ", Name = "Hacienda Arizona Y Villa Monica", Address = "Santa Rosa de Lima, paralelo 38", Phone = "3000000000", Created = DateTime.Now });

        }
    }
}
