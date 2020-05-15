using System;
using DotnetBoilerplate.Domain.Entities.Foobar;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureDefaults<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder)
            where TEntity : EntityBase<int, Guid>
        {
            entityTypeBuilder.HasKey(e => e.Id);
            entityTypeBuilder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}
