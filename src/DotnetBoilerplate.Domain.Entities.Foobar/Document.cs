namespace DotnetBoilerplate.Domain.Entities.Foobar
{
    public class Document : TenantEntityBase<long>
    {
        public string Name { get; set; }

        public int ScheduleId { get; set; }

        public int DocumentStatusId { get; set; }

        public Schedule Schedule { get; set; }

        public DocumentStatus DocumentStatus { get; set; }
    }
}
