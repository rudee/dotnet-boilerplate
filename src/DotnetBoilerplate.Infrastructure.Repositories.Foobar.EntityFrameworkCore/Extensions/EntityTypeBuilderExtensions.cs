using DotnetBoilerplate.Domain.Entities.Foobar;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureDefaults<TEntity, TId, TUserId>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : EntityBase<TId, TUserId>
            where TId     : struct
            where TUserId : struct
        {
            // EntityBase
            if (builder is EntityTypeBuilder<EntityBase<TId, TUserId>> entityBaseBuilder)
            {
                ConfigureEntityBaseDefaults<EntityBase<TId, TUserId>, TId, TUserId>(entityBaseBuilder);
            }

            // EntityWithGuidBase
            if (builder is EntityTypeBuilder<EntityWithGuidBase<TId, TUserId>> entityWithGuidBaseBuilder)
            {
                ConfigureEntityWithGuidBaseDefaults<EntityWithGuidBase<TId, TUserId>, TId, TUserId>(entityWithGuidBaseBuilder);
            }

            // TenantEntityBase
            if (builder is EntityTypeBuilder<TenantEntityBase<TId, TUserId>> tenantEntityBaseBuilder)
            {
                ConfigureTenantEntityBaseDefaults<TenantEntityBase<TId, TUserId>, TId, TUserId>(tenantEntityBaseBuilder);
            }

            // TenantEntityWithGuidBase
            if (builder is EntityTypeBuilder<TenantEntityWithGuidBase<TId, TUserId>> tenantEntityWithGuidBaseBuilder)
            {
                ConfigureTenantEntityWithGuidBaseDefaults<TenantEntityWithGuidBase<TId, TUserId>, TId, TUserId>(tenantEntityWithGuidBaseBuilder);
            }
        }

        private static void ConfigureEntityBaseDefaults<TEntity, TId, TUserId>(this EntityTypeBuilder<EntityBase<TId, TUserId>> builder)
            where TEntity : EntityBase<TId, TUserId>
            where TId     : struct
            where TUserId : struct
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RowVersion).IsRowVersion();
            builder.Property(e => e.CreatedOn).HasValueGenerator<UtcNowDateTimeValueGenerator>().ValueGeneratedOnAdd();
            builder.Property(e => e.ModifiedOn).HasValueGenerator<UtcNowDateTimeValueGenerator>().ValueGeneratedOnAddOrUpdate();
        }

        private static void ConfigureEntityWithGuidBaseDefaults<TEntity, TId, TUserId>(EntityTypeBuilder<EntityWithGuidBase<TId, TUserId>> builder)
            where TEntity : EntityWithGuidBase<TId, TUserId>
            where TId     : struct
            where TUserId : struct
        {
            builder.Property(e => e.Guid).HasValueGenerator<GuidValueGenerator>().ValueGeneratedOnAdd();
        }

        private static void ConfigureTenantEntityBaseDefaults<TEntity, TId, TUserId>(EntityTypeBuilder<TenantEntityBase<TId, TUserId>> builder)
            where TEntity : TenantEntityBase<TId, TUserId>
            where TId     : struct
            where TUserId : struct
        {
            builder.Property(e => e.TenantGuid).HasValueGenerator<GuidValueGenerator>().ValueGeneratedOnAdd();
        }

        private static void ConfigureTenantEntityWithGuidBaseDefaults<TEntity, TId, TUserId>(EntityTypeBuilder<TenantEntityWithGuidBase<TId, TUserId>> builder)
            where TEntity : TenantEntityWithGuidBase<TId, TUserId>
            where TId     : struct
            where TUserId : struct
        {
            builder.Property(e => e.TenantGuid).HasValueGenerator<GuidValueGenerator>().ValueGeneratedOnAdd();
        }
    }
}
