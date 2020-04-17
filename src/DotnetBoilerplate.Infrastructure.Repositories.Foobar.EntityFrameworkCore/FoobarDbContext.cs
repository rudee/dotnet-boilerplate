using DotnetBoilerplate.Domain.Entities.Foobar;
using DotnetBoilerplate.Infrastructure.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore
{
    public class FoobarDbContext : DbContext
    {
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<TenantUser> TenantUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public FoobarDbContext()
        {
        }

        public FoobarDbContext(DbContextOptions<FoobarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tenant
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.TenantId);
                entity.Property(p => p.RowVersion).IsRowVersion();
                entity.Property(p => p.Guid).HasValueGenerator<GuidValueGenerator>().ValueGeneratedOnAdd();
            });

            // TenantUser
            modelBuilder.Entity<TenantUser>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.UserId });
                entity.Property(p => p.RowVersion).IsRowVersion();
                entity.HasOne(d => d.Tenant).WithMany(p => p.TenantUsers).HasForeignKey(d => d.TenantId);
                entity.HasOne(d => d.User).WithMany(p => p.TenantUsers).HasForeignKey(d => d.UserId);
            });

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(p => p.RowVersion).IsRowVersion();
                entity.Property(p => p.Guid).HasValueGenerator<GuidValueGenerator>().ValueGeneratedOnAdd();
            });
        }
    }
}
