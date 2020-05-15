using System;

namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public abstract class TenantEntityBase : TenantEntityBase<int>
    {
    }

    public abstract class TenantEntityBase<TId> : TenantEntityBase<TId, Guid>
        where TId : struct
    {
    }

    public abstract class TenantEntityBase<TId, TUserId> : EntityBase<TId, TUserId>
        where TId     : struct
        where TUserId : struct
    {
        public virtual Guid TenantGuid { get; set; }
    }
}
