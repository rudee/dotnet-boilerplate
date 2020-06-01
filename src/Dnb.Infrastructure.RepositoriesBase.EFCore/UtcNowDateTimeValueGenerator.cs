using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Dnb.Infrastructure.RepositoriesBase.EFCore
{
    public class UtcNowDateTimeValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue(EntityEntry entry)
        {
            return DateTime.UtcNow;
        }
    }
}
