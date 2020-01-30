using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.ViewModels
{
    public class CountryViewModel
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset ActiveFrom { get; set; }
        public DateTimeOffset? ActiveTo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
