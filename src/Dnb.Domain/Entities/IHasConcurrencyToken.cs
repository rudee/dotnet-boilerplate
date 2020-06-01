namespace Dnb.Domain.Entities
{
    public interface IHasConcurrencyToken
    {
        public byte[] RowVersion { get; set; }
    }
}
