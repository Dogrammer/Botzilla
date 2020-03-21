﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;


namespace Botzilla.Core.CreateRequestModels
{
    public class CreateNewsRequest
    {
        public long Id { get; set; }
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
