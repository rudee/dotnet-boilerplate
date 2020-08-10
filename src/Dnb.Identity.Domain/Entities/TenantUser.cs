using System;

namespace Dnb.Identity.Domain.Entities
{
    public class TenantUser : EntityBase<long>
    {
        public Guid TenantId { get; set; }
        public Guid UserId { get; set; }

        public Tenant Tenant { get; set; }
        public User User { get; set; }
    }
}
