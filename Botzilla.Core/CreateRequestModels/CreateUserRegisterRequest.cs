using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Botzilla.Core.CreateRequestModels
{
    public class CreateUserRegisterRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        
        public string Gender { get; set; }
        public long EducationLevelId { get; set; }
        public string Role { get; set; }
    }
}
