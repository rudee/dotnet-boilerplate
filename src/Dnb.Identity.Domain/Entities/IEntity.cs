using System;

namespace Dnb.Identity.Domain.Entities
{
    public interface IEntity<TPrimaryKey> : Dnb.Domain.Entities.IEntity<TPrimaryKey, Guid>
        where TPrimaryKey : struct
    {
    }
}
