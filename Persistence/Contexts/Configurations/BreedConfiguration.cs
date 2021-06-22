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
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(ix => ix.Name).IsUnique();
            builder.HasData(
                new Breed { Id = 1, Name = "-No Asignado-", Created = DateTime.Now },
                new Breed { Id = 2, Name = "Angus", Created = DateTime.Now },
                new Breed { Id = 3, Name = "Angus Negro", Created = DateTime.Now },
                new Breed { Id = 4, Name = "Angus Rojo", Created = DateTime.Now },
                new Breed { Id = 5, Name = "Ayrshire", Created = DateTime.Now },
                new Breed { Id = 6, Name = "Bom", Created = DateTime.Now },
                new Breed { Id = 7, Name = "Brahman", Created = DateTime.Now },
                new Breed { Id = 8, Name = "Brangus", Created = DateTime.Now },
                new Breed { Id = 9, Name = "Casanareño", Created = DateTime.Now },
                new Breed { Id = 10, Name = "Cebu", Created = DateTime.Now },
                new Breed { Id = 11, Name = "Charolais", Created = DateTime.Now },
                new Breed { Id = 12, Name = "Chino Santandereano", Created = DateTime.Now },
                new Breed { Id = 13, Name = "Costeño con Cuernos", Created = DateTime.Now },
                new Breed { Id = 14, Name = "Criollo", Created = DateTime.Now },
                new Breed { Id = 15, Name = "Guzerat", Created = DateTime.Now },
                new Breed { Id = 16, Name = "Gyr", Created = DateTime.Now },
                new Breed { Id = 17, Name = "Harton del valle", Created = DateTime.Now },
                new Breed { Id = 18, Name = "Holstein", Created = DateTime.Now },
                new Breed { Id = 19, Name = "Indubrasil", Created = DateTime.Now },
                new Breed { Id = 20, Name = "Jersey", Created = DateTime.Now },
                new Breed { Id = 21, Name = "Limousin", Created = DateTime.Now },
                new Breed { Id = 22, Name = "Lucerna", Created = DateTime.Now },
                new Breed { Id = 23, Name = "Nelore", Created = DateTime.Now },
                new Breed { Id = 24, Name = "Normando", Created = DateTime.Now },
                new Breed { Id = 25, Name = "Pardo", Created = DateTime.Now },
                new Breed { Id = 26, Name = "Romosinuano", Created = DateTime.Now },
                new Breed { Id = 27, Name = "Sanmartinero", Created = DateTime.Now },
                new Breed { Id = 28, Name = "Simmental", Created = DateTime.Now },
                new Breed { Id = 29, Name = "Velasquez", Created = DateTime.Now });
        }
    }
}
