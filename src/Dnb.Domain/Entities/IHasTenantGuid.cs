using System;

namespace Dnb.Domain.Entities
{
    public interface IHasTenantGuid
    {
        public Guid TenantGuid { get; set; }
    }
}
