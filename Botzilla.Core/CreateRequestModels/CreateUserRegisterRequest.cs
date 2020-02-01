using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Botzilla.Core.CreateRequestModels
{
    public class CreateUserRegisterRequest
    {
        //[Required]
        //public string Username { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string FullName { get; set; }
        //public string Role { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
