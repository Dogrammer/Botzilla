using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.DomainInterfaces
{
    public interface ICreationAuditedEntity
    {
        DateTimeOffset DateCreated { get; set; }
        int? CreatedBy { get; set; }
    }
}
