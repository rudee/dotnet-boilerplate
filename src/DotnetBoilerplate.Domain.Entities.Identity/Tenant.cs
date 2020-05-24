using System;
using System.Collections.Generic;

namespace DotnetBoilerplate.Domain.Entities.Identity
{
    public class Tenant :
        EntityBase<int>,
        IEntity<int>,
        IGuidEntity
    {
        public Guid Guid { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }
    }
}
