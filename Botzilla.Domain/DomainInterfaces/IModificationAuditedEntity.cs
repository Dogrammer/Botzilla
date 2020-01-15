using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.DomainInterfaces
{
    public interface IModificationAuditedEntity
    {
        DateTimeOffset? LastModified { get; set; }
        int? ModifiedBy { get; set; }
    }
}
