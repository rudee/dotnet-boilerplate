using System.Linq;
using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ConfigureIEntityTypes<TId, TUserId>(this ModelBuilder modelBuilder)
            where TId     : struct
            where TUserId : struct
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IEntity<TId, TUserId>).IsAssignableFrom(t.ClrType)))
            {
                // Id
                IMutableProperty id = entityType.FindProperty(nameof(IEntity<TId, TUserId>.Id));
                entityType.SetPrimaryKey(id);

                // CreatedOn
                IMutableProperty createdOn = entityType.FindProperty(nameof(IEntity<TId, TUserId>.CreatedOn));
                createdOn.SetValueGeneratorFactory((p, e) => new UtcNowDateTimeValueGenerator());
                createdOn.ValueGenerated = ValueGenerated.OnAdd;
                createdOn.SetValueConverter(new UtcDateTimeValueConverter());

                // ModifiedOn
                IMutableProperty modifiedOn = entityType.FindProperty(nameof(IEntity<TId, TUserId>.ModifiedOn));
                modifiedOn.SetValueGeneratorFactory((p, e) => new UtcNowDateTimeValueGenerator());
                // Workaround. See: https://github.com/dotnet/efcore/issues/6999
                //modifiedOn.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                modifiedOn.ValueGenerated = ValueGenerated.OnAdd;
                modifiedOn.SetValueConverter(new UtcDateTimeValueConverter());

                // RowVersion
                IMutableProperty rowVersion = entityType.FindProperty(nameof(IEntity<TId, TUserId>.RowVersion));
                rowVersion.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                rowVersion.IsConcurrencyToken = true;
            }

            return modelBuilder;
        }

        public static ModelBuilder ConfigureIGuidEntityTypes(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes().Where(t => typeof(IGuidEntity).IsAssignableFrom(t.ClrType)))
            {
                // Guid
                IMutableProperty guid = entityType.FindProperty(nameof(IGuidEntity.Guid));
                guid.SetValueGeneratorFactory((p, e) => new GuidValueGenerator());
                guid.ValueGenerated = ValueGenerated.OnAdd;
            }

            return modelBuilder;
        }
    }
}
