using System;

namespace Dnb.Domain.Entities
{
    public interface IHasGuid
    {
        public Guid Guid { get; set; }
    }
}
