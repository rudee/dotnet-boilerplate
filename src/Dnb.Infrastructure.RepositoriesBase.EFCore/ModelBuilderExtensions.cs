using System.Linq;
using Dnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dnb.Infrastructure.RepositoriesBase.EFCore
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ConfigureIEntityTypes<TPrimaryKey, TUserId>(this ModelBuilder modelBuilder)
            where TPrimaryKey : struct
            where TUserId     : struct
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IEntity<TPrimaryKey, TUserId>).IsAssignableFrom(t.ClrType)))
            {
                // Id
                IMutableProperty id = entityType.FindProperty(nameof(IEntity<TPrimaryKey, TUserId>.Id));
                // Set Id property as primary key
                entityType.SetPrimaryKey(id);

                // CreatedOn
                IMutableProperty createdOn = entityType.FindProperty(nameof(IEntity<TPrimaryKey, TUserId>.CreatedOn));
                // Generate value on add
                createdOn.SetValueGeneratorFactory((p, e) => new UtcNowDateTimeValueGenerator());
                createdOn.ValueGenerated = ValueGenerated.OnAdd;
                // Convert value
                createdOn.SetValueConverter(new UtcDateTimeValueConverter());

                // ModifiedOn
                IMutableProperty modifiedOn = entityType.FindProperty(nameof(IEntity<TPrimaryKey, TUserId>.ModifiedOn));
                // Generate value on add
                modifiedOn.SetValueGeneratorFactory((p, e) => new UtcNowDateTimeValueGenerator());
                // Workaround. See: https://github.com/dotnet/efcore/issues/6999
                //modifiedOn.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                modifiedOn.ValueGenerated = ValueGenerated.OnAdd;
                // Convert value
                modifiedOn.SetValueConverter(new UtcDateTimeValueConverter());
            }

            return modelBuilder;
        }

        public static ModelBuilder ConfigureIHasConcurrencyTokenTypes(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IHasConcurrencyToken).IsAssignableFrom(t.ClrType)))
            {
                // RowVersion
                IMutableProperty rowVersion = entityType.FindProperty(nameof(IHasConcurrencyToken.RowVersion));
                // Generate value on add or update
                rowVersion.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                // Is concurrency token
                rowVersion.IsConcurrencyToken = true;
            }

            return modelBuilder;
        }

        public static ModelBuilder ConfigureIHasGuidTypes(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IHasGuid).IsAssignableFrom(t.ClrType)))
            {
                // Guid
                IMutableProperty guid = entityType.FindProperty(nameof(IHasGuid.Guid));
                // Generate Guid property on add
                guid.SetValueGeneratorFactory((p, e) => new GuidValueGenerator());
                guid.ValueGenerated = ValueGenerated.OnAdd;
            }

            return modelBuilder;
        }
    }
}
