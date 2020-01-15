using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.DomainInterfaces
{
    public interface IDeletionAuditedEntity
    {
        DateTimeOffset? DateDeleted { get; set; }
        int? DeletedBy { get; set; }
    }
}
