namespace DotnetBoilerplate.Domain.Entities.Identity
{
    public class TenantUser :
        EntityBase<long>,
        IEntity<long>
    {
        public int TenantId { get; set; }

        public int UserId { get; set; }

        public Tenant Tenant { get; set; }

        public User User { get; set; }
    }
}
