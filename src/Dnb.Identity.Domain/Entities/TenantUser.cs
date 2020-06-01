namespace Dnb.Identity.Domain.Entities
{
    public class TenantUser : EntityBase<long>
    {
        public int TenantId { get; set; }
        public int UserId { get; set; }

        public Tenant Tenant { get; set; }
        public User User { get; set; }
    }
}
