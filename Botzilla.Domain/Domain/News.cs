using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.Domain
{
    public class News
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageBase64 { get; set; }


    }
}
