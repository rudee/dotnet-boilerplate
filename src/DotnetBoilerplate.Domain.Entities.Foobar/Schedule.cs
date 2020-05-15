using System.Collections.Generic;

namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public class Schedule : TenantEntityBase<long>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
