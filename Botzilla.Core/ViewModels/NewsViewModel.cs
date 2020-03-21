using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.ViewModels
{
    public class NewsViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
    }
}
