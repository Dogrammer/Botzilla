using Botzilla.Domain.DomainBaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Botzilla.Domain.Domain
{
    public class NewsImage : BaseEntity
    {
            public string ImageTitle { get; set; }
            public byte[] ImageData { get; set; }
    }
}
