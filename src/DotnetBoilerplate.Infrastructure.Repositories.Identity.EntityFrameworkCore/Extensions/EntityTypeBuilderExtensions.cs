using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        //public static void ConfigureDefaults1<TEntity>(this EntityTypeBuilder<TEntity> builder)
        //    where TEntity : class
        public static void ConfigureDefaults1<IEntity, TId, TUserId>(this EntityTypeBuilder<IEntity<TId, TUserId>> builder)
            //where TEntity : class, IEntity<TId, TUserId>
            where TId : struct
            where TUserId : struct
        {
            (builder as EntityTypeBuilder<IEntity<TId, TUserId>>)?.ConfigureDefaults();

            //if (typeof(IEntity<,>).IsAssignableFrom(typeof(IEntity<TId, TUserId>)))
            //{
            //    (builder as EntityTypeBuilder<IEntity<,>>)?.ConfigureDefaults();

            //    builder.Test<TEntity, int, int>();

            //    var entityBuilder = builder as EntityTypeBuilder<IEntity<int, int>>;
            //    entityBuilder.Test<Tenant, int, int>();

            //    entityBuilder.HasKey(e => e.Id);
            //    entityBuilder.Property(e => e.CreatedOn).HasValueGenerator<DateTimeValueGenerator>().ValueGeneratedOnAdd();
            //    entityBuilder.Property(e => e.ModifiedOn).HasValueGenerator<DateTimeValueGenerator>().ValueGeneratedOnAddOrUpdate();
            //    entityBuilder.Property(e => e.RowVersion).IsRowVersion();
            //}




            if (typeof(EntityTypeBuilder<IGuidEntity>).IsAssignableFrom(builder.GetType()))
            {
                (builder as EntityTypeBuilder<IGuidEntity>)?.ConfigureDefaults();
            }
        }

        private static void ConfigureDefaults<TId, TUserId>(this EntityTypeBuilder<IEntity<TId, TUserId>> builder)
            where TId : struct
            where TUserId : struct
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedOn).HasValueGenerator<UtcNowDateTimeValueGenerator>().ValueGeneratedOnAdd();
            builder.Property(e => e.ModifiedOn).HasValueGenerator<UtcNowDateTimeValueGenerator>().ValueGeneratedOnAddOrUpdate();
            builder.Property(e => e.RowVersion).IsRowVersion();
        }

        private static void ConfigureDefaults(this EntityTypeBuilder<IGuidEntity> builder)
        {
            builder.Property(e => e.Guid).HasValueGenerator<GuidValueGenerator>().ValueGeneratedOnAdd();
        }






        /*
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
        */
    }
}
