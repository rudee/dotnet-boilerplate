using System.Collections.Generic;

namespace DotnetBoilerplate.Domain.Entities.Identity
{
    public class User : EntityWithGuidBase
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }
    }
}
