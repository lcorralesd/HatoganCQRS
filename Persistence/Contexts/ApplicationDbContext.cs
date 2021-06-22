using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTimeService = dateTimeService;
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Farm> Farms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            BeforeSave();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSave()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<EntityBase>())
            {
                if (auditableEntity.State is EntityState.Added or EntityState.Modified)
                {
                    var date = _dateTimeService.NowUtc;
                    var user = "system";

                    auditableEntity.Entity.LastUpdated = date;
                    auditableEntity.Entity.LastUpdatedBy = user;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.Created = date;
                        auditableEntity.Entity.CreatedBy = user;
                    }
                    else
                    {
                        auditableEntity.Property(x => x.Created).IsModified = false;
                        auditableEntity.Property(x => x.CreatedBy).IsModified = false;
                    }
                }
            }
        }
    }
}
