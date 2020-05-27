using System;
using System.Collections.Generic;
using System.Linq;
using DotnetBoilerplate.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore
{
    public static class EntityEntryExtensions
    {
        public static void OverrideIEntityProperties<TId, TUserId>(this IEnumerable<EntityEntry> entityEntries)
            where TId     : struct
            where TUserId : struct
        {
            foreach (EntityEntry entityEntry in entityEntries.Where(ee => typeof(IEntity<TId, TUserId>).IsAssignableFrom(ee.Entity.GetType())))
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    // Modified - Update the Modified property
                    ((IEntity<TId, TUserId>)entityEntry.Entity).ModifiedOn = DateTime.UtcNow;
                    entityEntry.Property(nameof(IEntity<TId, TUserId>.ModifiedOn)).IsModified = true;
                }
            }
        }
    }
}
