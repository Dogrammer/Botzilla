using Botzilla.Domain.DomainBaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.DomainInterfaces
{
    public interface ITrackable
    {
        //
        // Summary:
        //     Change-tracking state of an entity.
        TrackingState TrackingState { get; set; }
        //
        // Summary:
        //     Properties on an entity that have been modified.
        ICollection<string> ModifiedProperties { get; set; }
    }
}
