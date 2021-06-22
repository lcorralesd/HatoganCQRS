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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(20);
            builder.HasData(
                new Category { Id = 1, Name = "Crias", Created = DateTime.Now, CreatedBy = "system" },
                new Category { Id = 2, Name = "Novillas", Created = DateTime.Now, CreatedBy = "system" },
                new Category { Id = 3, Name = "Mautes", Created = DateTime.Now, CreatedBy = "system" },
                new Category { Id = 4, Name = "Vacas", Created = DateTime.Now, CreatedBy = "system" },
                new Category { Id = 5, Name = "Toros", Created = DateTime.Now, CreatedBy = "system" });
        }
    }
}
