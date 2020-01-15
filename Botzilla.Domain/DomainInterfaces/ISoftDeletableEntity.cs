using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.DomainInterfaces
{
    public interface ISoftDeletableEntity
    {
        bool IsDeleted { get; set; }
    }
}
