using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.CreateRequestModels
{
    public class CreateImageRequest
    {
        public IFormFile File { get; set; }
        public string ImageTitle { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }


    }
}
