using System;

namespace DotnetBoilerplate.Domain.Entities.Identity
{
    public abstract class EntityWithGuidBase : EntityWithGuidBase<int>
    {
    }

    public abstract class EntityWithGuidBase<TId> : EntityWithGuidBase<TId, int>
        where TId : struct
    {
    }

    public abstract class EntityWithGuidBase<TId, TUserId> : EntityBase<TId, TUserId>
        where TId     : struct
        where TUserId : struct
    {
        public virtual Guid Guid { get; set; }
    }
}
