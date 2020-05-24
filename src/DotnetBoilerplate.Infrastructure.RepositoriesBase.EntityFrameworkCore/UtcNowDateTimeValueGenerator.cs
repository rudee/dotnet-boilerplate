using System;
using System.Threading;
using System.Threading.Tasks;
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

        protected override ValueTask<object> NextValueAsync(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            return new ValueTask<object>(DateTime.UtcNow);
        }
    }
}
