using System;

namespace Dnb.Domain.Entities
{
    public abstract class EntityBase<TPrimaryKey, TUserId> :
        IEntity<TPrimaryKey, TUserId>
        where TPrimaryKey : struct
        where TUserId     : struct
    {
        public virtual TPrimaryKey Id         { get; set; }
        public virtual DateTime    CreatedOn  { get; set; }
        public virtual TUserId     CreatedBy  { get; set; }
        public virtual DateTime    ModifiedOn { get; set; }
        public virtual TUserId     ModifiedBy { get; set; }
    }
}
