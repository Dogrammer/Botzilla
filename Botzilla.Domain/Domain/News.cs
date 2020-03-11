using Botzilla.Domain.DomainBaseClasses;
using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Botzilla.Domain.Domain
{
    public class News : BaseEntity, IActiveFromToEntity
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        [NotMapped]
        public string ImageBase64 { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset ActiveFrom { get; set; }
        public DateTimeOffset? ActiveTo { get; set; }
    }
}
