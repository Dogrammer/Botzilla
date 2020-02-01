using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Botzilla.Domain.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Botzilla.Api.Controllers.Auth
{
    [Authorize(AuthenticationSchemes =
    JwtBearerDefaults.AuthenticationScheme)]
    [Route("Api/[controller]")]
    [ApiController]
    public class SafeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public SafeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        //[HttpGet]
        //[Route("GetUser")]
        //public async Task<IActionResult> GetMessageAsync()
        //{
        //    var user = await GetCurrentUserAsync();
        //    if (user != null)
        //    {
        //        return Ok(user);

        //    }
        //    return BadRequest("Error");
        //}

        //private async Task<IdentityUser> GetCurrentUserAsync()
        //{
        //    string userName = HttpContext.User.Identity.Name;
        //    return await _userManager.FindByNameAsync(userName);
        //}



    }
}