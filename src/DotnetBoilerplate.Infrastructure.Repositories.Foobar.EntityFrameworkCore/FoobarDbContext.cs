using System;
using DotnetBoilerplate.Domain.Entities.Foobar;
using DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore.Extensions;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore
{
    public class FoobarDbContext : DbContext
    {
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentStatus> DocumentStatus { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }

        public FoobarDbContext()
        {
        }

        public FoobarDbContext(DbContextOptions<FoobarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Document
            modelBuilder.Entity<Document>(builder =>
            {
                builder.ConfigureDefaults<Document, long, Guid>();

                builder
                    .HasOne(d => d.Schedule)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.ScheduleId);

                builder
                    .HasOne(d => d.DocumentStatus)
                    .WithMany();
            });

            // DocumentStatus
            modelBuilder.Entity<DocumentStatus>(entity =>
            {
                entity.ConfigureDefaults<DocumentStatus, int, Guid>();
            });

            // Schedule
            modelBuilder.Entity<Schedule>(builder =>
            {
                builder.ConfigureDefaults<Schedule, long, Guid>();
            });
        }
    }
}
