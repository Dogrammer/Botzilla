using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Botzilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        //private readonly SignInManager<User> _signInManager;
        //private readonly UserManager<User> _userManager;
        //private readonly IConfiguration _config;

        //public AuthController(ApplicationDbContext context,
        //SignInManager<User> signInManager,
        //UserManager<User> userManager,
        //IConfiguration config)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _context = context;
        //    _config = config;
        //}

        //[HttpPost("register")]
        //public async Task<object> AddUser([FromBody]CreateUserRegisterRequest registerRequest)
        //{
        //    registerRequest.Role = "PremiumUser";
        //    var OldUser = await _userManager.FindByNameAsync(registerRequest.Username);

        //    if (OldUser != null)
        //        return BadRequest("User with username already exists");

        //    var appUser = new User()
        //    {
        //        UserName = registerRequest.Username,
        //        Email = registerRequest.Email,
        //        FullName = registerRequest.FullName
        //    };

        //    try
        //    {
        //        var result = await _userManager.CreateAsync(appUser, registerRequest.Password);
        //        await _userManager.AddToRoleAsync(appUser, registerRequest.Role);
        //        return Ok(result);
        //    }

        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(CreateUserLoginRequest loginRequest)
        //{
        //    var user = await _userManager.FindByNameAsync(loginRequest.UserName);

        //    if (user != null && await _userManager.CheckPasswordAsync(user, loginRequest.Password))
        //    {
        //        // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
        //        //get role assigned to the user
        //        var role = await _userManager.GetRolesAsync(user);
        //        IdentityOptions _options = new IdentityOptions();

        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim("UserID", user.Id.ToString()),
        //                new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
        //            }),
        //            Expires = DateTime.UtcNow.AddHours(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value)), SecurityAlgorithms.HmacSha512Signature)
        //        };
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //        var token = tokenHandler.WriteToken(securityToken);

        //        return Ok(new { token });
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //    }
        //}
    }
}