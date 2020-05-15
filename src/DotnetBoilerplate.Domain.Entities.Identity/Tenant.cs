using System.Collections.Generic;

namespace DotnetBoilerplate.Domain.Entities.Identity
{
    public class Tenant : EntityWithGuidBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }
    }
}
