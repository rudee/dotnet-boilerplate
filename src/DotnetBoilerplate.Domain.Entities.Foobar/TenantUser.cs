namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public class TenantUser : EntityBase
    {
        public int TenantId { get; set; }

        public int UserId { get; set; }

        public Tenant Tenant { get; set; }

        public User User { get; set; }
    }
}
