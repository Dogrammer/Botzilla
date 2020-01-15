using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.DomainInterfaces
{
    public interface IActiveFromToEntity
    {
        bool IsActive { get; set; }
        DateTimeOffset ActiveFrom { get; set; }
        DateTimeOffset? ActiveTo { get; set; }
    }
}
