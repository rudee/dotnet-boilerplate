using System;

namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public abstract class EntityBase : EntityBase<int>
    {
    }

    public abstract class EntityBase<TUserId>
        where TUserId : struct
    {
        public virtual DateTime CreatedOn { get; set; }
        public virtual TUserId CreatedBy { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public virtual TUserId ModifiedBy { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}
