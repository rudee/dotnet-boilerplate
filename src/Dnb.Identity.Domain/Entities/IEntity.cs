namespace Dnb.Identity.Domain.Entities
{
    public interface IEntity<TPrimaryKey> : Dnb.Domain.Entities.IEntity<TPrimaryKey, int>
        where TPrimaryKey : struct
    {
    }
}
