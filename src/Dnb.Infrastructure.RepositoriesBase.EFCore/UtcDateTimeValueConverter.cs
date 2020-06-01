using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dnb.Infrastructure.RepositoriesBase.EFCore
{
    /// <summary>
    /// Sets the DateTimeKind to UTC for DateTime properties.
    /// This ValueConverter is necessary because DateTime entity properties always have
    /// DateTimeKind=Unspecified when loading from the database when the column type is datetime2.
    /// </summary>
    public class UtcDateTimeValueConverter : ValueConverter<DateTime, DateTime>
    {
        public UtcDateTimeValueConverter()
            : base(d => DateTime.SpecifyKind(d, DateTimeKind.Utc),
                   d => DateTime.SpecifyKind(d, DateTimeKind.Utc))
        {
        }
    }
}
