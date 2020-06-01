using System;

namespace Dnb.Domain.Entities
{
    public interface IEntity<TPrimaryKey, TUserId>
        where TPrimaryKey : struct
        where TUserId     : struct
    {
        public TPrimaryKey Id         { get; set; }
        public DateTime    CreatedOn  { get; set; }
        public TUserId     CreatedBy  { get; set; }
        public DateTime    ModifiedOn { get; set; }
        public TUserId     ModifiedBy { get; set; }
    }
}
