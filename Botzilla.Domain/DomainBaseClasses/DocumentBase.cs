using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Botzilla.Domain.DomainBaseClasses
{
    public class DocumentBase : BaseEntity
    {
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTimeOffset ActiveFrom { get; set; }

        public DateTimeOffset? ActiveTo { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Document Name must be between 2 and 50 characters"), MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public long FileSize { get; set; }

        [Required]
        public string Extension { get; set; }

        [NotMapped]
        public string Base64 { get; set; }
    }
}
