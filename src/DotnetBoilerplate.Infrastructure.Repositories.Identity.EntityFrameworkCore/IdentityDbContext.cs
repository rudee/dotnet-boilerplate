using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore
{
    public class IdentityDbContext : DbContext
    {
        public virtual DbSet<Tenant>     Tenant     { get; set; }
        public virtual DbSet<TenantUser> TenantUser { get; set; }
        public virtual DbSet<User>       User       { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IEntity<int, int>
            modelBuilder.ConfigureIEntityTypes<int, int>();

            // IEntity<long, int>
            modelBuilder.ConfigureIEntityTypes<long, int>();

            // IGuidEntity
            modelBuilder.ConfigureIGuidEntityTypes();

            // Tenant
            modelBuilder.Entity<Tenant>(builder =>
            {
            });

            // TenantUser
            modelBuilder.Entity<TenantUser>(builder =>
            {
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
            });
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            OnSaveChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken)
                .ConfigureAwait(false);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return await base.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        private void OnSaveChanges()
        {
            IEnumerable<EntityEntry> entityEntries = ChangeTracker.Entries();
            entityEntries.OverrideIEntityProperties<int, int>();
            entityEntries.OverrideIEntityProperties<long, int>();
        }
    }
}
