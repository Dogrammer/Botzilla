using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.ViewModels
{
    public class NewsViewModel
    {
        public string Base64 { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
    }
}
