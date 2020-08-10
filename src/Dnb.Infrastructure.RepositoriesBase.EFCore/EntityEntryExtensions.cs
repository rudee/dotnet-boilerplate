using System;
using System.Collections.Generic;
using System.Linq;
using Dnb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dnb.Infrastructure.RepositoriesBase.EFCore
{
    public static class EntityEntryExtensions
    {
        public static void OverrideIEntityProperties<TPrimaryKey, TUserId>(this IEnumerable<EntityEntry> entityEntries)
            where TPrimaryKey : struct
            where TUserId     : struct
        {
            foreach (EntityEntry entityEntry in entityEntries.Where(ee => typeof(IEntity<TPrimaryKey, TUserId>).IsAssignableFrom(ee.Entity.GetType())))
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    // Update the ModifiedOn property
                    ((IEntity<TPrimaryKey, TUserId>)entityEntry.Entity).ModifiedOn = DateTime.UtcNow;
                    entityEntry.Property(nameof(IEntity<TPrimaryKey, TUserId>.ModifiedOn)).IsModified = true;
                }
            }
        }
    }
}
