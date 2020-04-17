using System;
using System.Collections.Generic;

namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public class User : EntityBase
    {
        public int UserId { get; set; }

        public Guid Guid { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }
    }
}
