using System;

namespace DotnetBoilerplate.Domain.Entities.Identity
{
    public abstract class EntityBase<TId> : EntityBase<TId, int>
        where TId : struct
    {
    }

    public abstract class EntityBase<TId, TUserId>
        where TId     : struct
        where TUserId : struct
    {
        public virtual TId      Id         { get; set; }
        public virtual DateTime CreatedOn  { get; set; }
        public virtual TUserId  CreatedBy  { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public virtual TUserId  ModifiedBy { get; set; }
        public virtual byte[]   RowVersion { get; set; }
    }
}
