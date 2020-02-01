using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthController(ApplicationDbContext context,
        SignInManager<User> signInManager,
        IMapper mapper,
        UserManager<User> userManager,
        IConfiguration config)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            //_context = context;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] CreateUserLoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)

                }),
                    Issuer = "https://spark.ooo",
                    Audience = "https://spark.ooo",
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A-VERY-STRONG-KEY-HERE")), SecurityAlgorithms.HmacSha512Signature),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    expiration = token.ValidTo //A UTC TIME FORMAT WITH T AND Z
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRegisterRequest input)
        {
            
            var OldUser = await _userManager.FindByEmailAsync(input.Email);

            if (OldUser != null)
            {
                return BadRequest("This email is already registered");
            }

            if (ModelState.IsValid)
            {
                //var user = new IdentityUser { UserName = input.Email, Email = input.Email };
                //var user = new User { UserName = input.Email, Email = input.Email };
                var mappedUser = _mapper.Map<User>(input);
                mappedUser.Email = input.Email;
                mappedUser.UserName = input.Email;
                var result = await _userManager.CreateAsync(mappedUser, input.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(mappedUser);

                    //DO YOUR STUFF HERE

                    //EMAIL VERIFICATION CODE
                    //If you want to add Email verificiation then uncoment two lines of Email and add Scoped services in Startup.cs with Definations.
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code },
                    //    protocol: Request.Scheme);                 
                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    // $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    return Ok("Successful Registration"); //Send Result or Message whatever you like.
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return new JsonResult(ModelState);
                }

            }
            else
            {
                return new JsonResult("Error Here"); ;
            }
        }




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