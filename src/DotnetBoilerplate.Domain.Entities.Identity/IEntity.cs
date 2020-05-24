using System;

namespace DotnetBoilerplate.Domain.Entities.Identity
{
    public interface IEntity<TId> : IEntity<TId, int>
        where TId : struct
    {
    }

    public interface IEntity<TId, TUserId>
        where TId     : struct
        where TUserId : struct
    {
        public TId      Id         { get; set; }
        public DateTime CreatedOn  { get; set; }
        public TUserId  CreatedBy  { get; set; }
        public DateTime ModifiedOn { get; set; }
        public TUserId  ModifiedBy { get; set; }
        public byte[]   RowVersion { get; set; }
    }
}
