using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore.Extensions
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
        }

        private static void ConfigureEntityBaseDefaults<TEntity, TId, TUserId>(this EntityTypeBuilder<EntityBase<TId, TUserId>> builder)
            where TEntity : EntityBase<TId, TUserId>
            where TId     : struct
            where TUserId : struct
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RowVersion).IsRowVersion();
            builder.Property(e => e.CreatedOn).HasValueGenerator<DateTimeValueGenerator>().ValueGeneratedOnAdd();
            builder.Property(e => e.ModifiedOn).HasValueGenerator<DateTimeValueGenerator>().ValueGeneratedOnAddOrUpdate();
        }

        private static void ConfigureEntityWithGuidBaseDefaults<TEntity, TId, TUserId>(EntityTypeBuilder<EntityWithGuidBase<TId, TUserId>> builder)
            where TEntity : EntityWithGuidBase<TId, TUserId>
            where TId     : struct
            where TUserId : struct
        {
            builder.Property(e => e.Guid).HasValueGenerator<GuidValueGenerator>().ValueGeneratedOnAdd();
        }
    }
}
