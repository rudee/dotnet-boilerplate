namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public class DocumentStatus : TenantEntityBase<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
