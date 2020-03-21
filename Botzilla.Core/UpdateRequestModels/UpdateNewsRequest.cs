using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.UpdateRequestModels
{
    public class UpdateNewsRequest
    {
        public long Id { get; set; }
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
