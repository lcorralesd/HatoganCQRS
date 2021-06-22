using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(a => a.Code).IsRequired().HasMaxLength(15);
            builder.Property(a => a.EarTag).HasMaxLength(15);
            builder.Property(a => a.Name).HasMaxLength(20);
            builder.Property(a => a.Color).HasMaxLength(20);
            builder.Property(a => a.Status).HasMaxLength(10).HasConversion(new EnumToStringConverter<Status>());
            builder.Property(a => a.Sex).HasMaxLength(10).HasConversion(new EnumToStringConverter<Sex>());
            builder.Property(a => a.AdmissionDate).HasColumnType("date");
            builder.Property(a => a.BirthDate).HasColumnType("date");
            builder.Property(a => a.IncomeWeight).HasColumnType("decimal(18,2)");
            builder.Property(a => a.BirthWeight).HasColumnType("decimal(18,2)");
            builder.HasMany(cr => cr.DamPups).WithOne(a => a.Dam).HasForeignKey(fk => fk.DamId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(cr => cr.SirePups).WithOne(a => a.Sire).HasForeignKey(fk => fk.SireId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(ix => ix.Code).IsUnique();
        }
    }
}
