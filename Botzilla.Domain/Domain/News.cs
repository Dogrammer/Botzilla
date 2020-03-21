using Botzilla.Domain.DomainBaseClasses;
using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Botzilla.Domain.Domain
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string FileType { get; set; }
    }
}
