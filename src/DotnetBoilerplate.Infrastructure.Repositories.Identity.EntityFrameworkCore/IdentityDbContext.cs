using System;
using System.Collections.Generic;
using System.Linq;
using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore.Extensions;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore
{
    public class IdentityDbContext : DbContext
    {
        public virtual DbSet<Tenant>     Tenant     { get; set; }
        public virtual DbSet<TenantUser> TenantUser { get; set; }
        public virtual DbSet<User>       User       { get; set; }

        public IdentityDbContext()
        {
        }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IEntity<int>
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IEntity<int>).IsAssignableFrom(t.ClrType)))
            {
                var properties = entityType.GetProperties();
                var declaredProperties = entityType.GetDeclaredProperties();

                //builder.HasKey(e => e.Id);
                //builder.Property(e => e.CreatedOn).HasValueGenerator<DateTimeValueGenerator>().ValueGeneratedOnAdd();
                //builder.Property(e => e.ModifiedOn).HasValueGenerator<DateTimeValueGenerator>().ValueGeneratedOnAddOrUpdate();
                //builder.Property(e => e.RowVersion).IsRowVersion();

                IMutableProperty id = entityType.FindProperty(nameof(IEntity<int>.Id));
                entityType.SetPrimaryKey(id);

                IMutableProperty createdOn = entityType.FindProperty(nameof(IEntity<int>.CreatedOn));
                createdOn.SetValueGeneratorFactory((p, e) => new UtcNowDateTimeValueGenerator());
                createdOn.ValueGenerated = ValueGenerated.OnAdd;

                IMutableProperty modifiedOn = entityType.FindProperty(nameof(IEntity<int>.ModifiedOn));
                modifiedOn.SetValueGeneratorFactory((p, e) => new UtcNowDateTimeValueGenerator());
                //modifiedOn.ValueGenerated = ValueGenerated.OnAddOrUpdate; // See: https://github.com/dotnet/efcore/issues/6999
                modifiedOn.ValueGenerated = ValueGenerated.OnAdd;

                IMutableProperty rowVersion = entityType.FindProperty(nameof(IEntity<int>.RowVersion));
                rowVersion.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                rowVersion.IsConcurrencyToken = true;
            }

            // IEntity<long>
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IEntity<long>).IsAssignableFrom(t.ClrType)))
            {
                var properties = entityType.GetProperties();
                var declaredProperties = entityType.GetDeclaredProperties();
                //IMutableProperty guid = entityType.FindProperty(nameof(IEntity.Id));
            }

            // IGuidEntity
            foreach (IMutableEntityType guidEntityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IGuidEntity).IsAssignableFrom(t.ClrType)))
            {
                IMutableProperty guid = guidEntityType.FindProperty(nameof(IGuidEntity.Guid));
                guid.SetValueGeneratorFactory((p, e) => new GuidValueGenerator());
                guid.ValueGenerated = ValueGenerated.OnAdd;
            }

            // Tenant
            modelBuilder.Entity<Tenant>(builder =>
            {
                //builder.ConfigureDefaults<Tenant, int, int>();

                //builder.ConfigureDefaults1();
                //builder.Property(e => e.RowVersion).IsRowVersion();
            });

            // TenantUser
            modelBuilder.Entity<TenantUser>(builder =>
            {
                //builder.ConfigureDefaults<TenantUser, long, int>();

                // Tenant-User many-to-many relationship
                builder
                    .HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantUsers)
                    .HasForeignKey(d => d.TenantId);
                builder
                    .HasOne(d => d.User)
                    .WithMany(p => p.TenantUsers)
                    .HasForeignKey(d => d.UserId);
            });

            // User
            modelBuilder.Entity<User>(builder =>
            {
                //builder.ConfigureDefaults<User, int, int>();
            });
        }
    }
}
