using Botzilla.Domain.DomainBaseClasses;
using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Botzilla.Domain.Domain
{
    public class Country : BaseEntity, IActiveFromToEntity
    {
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTimeOffset ActiveFrom { get; set; }

        public DateTimeOffset? ActiveTo { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Country name must be between 2 and 50 characters"), MinLength(2)]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "The Country description must be between 2 and 250 characters"), MinLength(2)]
        public string Description { get; set; }
        public bool IsPrimary { get; set; }
    }
}
