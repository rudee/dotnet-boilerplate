using System;

namespace Dnb.Identity.Domain.Entities
{
    public abstract class EntityBase<TPrimaryKey> : Dnb.Domain.Entities.EntityBase<TPrimaryKey, Guid>,
        IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
    }
}
