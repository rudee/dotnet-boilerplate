using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore
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
