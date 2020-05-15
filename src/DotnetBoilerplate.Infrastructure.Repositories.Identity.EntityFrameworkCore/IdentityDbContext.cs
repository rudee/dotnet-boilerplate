using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore
{
    public class IdentityDbContext : DbContext
    {
        public virtual DbSet<Tenant>     Tenants     { get; set; }
        public virtual DbSet<TenantUser> TenantUsers { get; set; }
        public virtual DbSet<User>       Users       { get; set; }

        public IdentityDbContext()
        {
        }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tenant
            modelBuilder.Entity<Tenant>(builder =>
            {
                builder.ConfigureDefaults<Tenant, int, int>();
            });

            // TenantUser
            modelBuilder.Entity<TenantUser>(builder =>
            {
                builder.ConfigureDefaults<TenantUser, long, int>();

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
                builder.ConfigureDefaults<User, int, int>();
            });
        }
    }
}
