using System;

namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public abstract class TenantEntityWithGuidBase : TenantEntityWithGuidBase<int, Guid>
    {
    }

    public abstract class TenantEntityWithGuidBase<TId> : TenantEntityWithGuidBase<TId, Guid>
        where TId : struct
    {
    }

    public abstract class TenantEntityWithGuidBase<TId, TUserId> : EntityWithGuidBase<TId, TUserId>
        where TId     : struct
        where TUserId : struct
    {
        public virtual Guid TenantGuid { get; set; }
    }
}
