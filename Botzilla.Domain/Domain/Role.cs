using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Domain.Domain
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
