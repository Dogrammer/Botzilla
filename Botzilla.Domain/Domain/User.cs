//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Botzilla.Domain.Domain
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
        public string Role { get; set; }

        [ForeignKey("EducationLevelId")]
        public EducationLevel? EducationLevel { get; set; }
        public long? EducationLevelId { get; set; }
        public string Gender { get; set; }

    }
}
