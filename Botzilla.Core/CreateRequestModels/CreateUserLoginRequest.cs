using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.CreateRequestModels
{
    public class CreateUserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
