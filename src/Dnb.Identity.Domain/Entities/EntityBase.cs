namespace Dnb.Identity.Domain.Entities
{
    public abstract class EntityBase<TPrimaryKey> : Dnb.Domain.Entities.EntityBase<TPrimaryKey, int>,
        IEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
    }
}
