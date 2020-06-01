using System;
using System.Collections.Generic;

namespace Dnb.Identity.Domain.Entities
{
    public class User : EntityBase<int>,
        Dnb.Domain.Entities.IHasConcurrencyToken,
        Dnb.Domain.Entities.IHasGuid,
        Dnb.Domain.Entities.ISoftDelete
    {
        public byte[] RowVersion { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }
    }
}
