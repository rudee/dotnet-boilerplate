using System;
using System.Collections.Generic;

namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public class Tenant : EntityBase
    {
        public int TenantId { get; set; }

        public Guid Guid { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }
    }
}
