using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Botzilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;

        }
        
        // [AllowAnonymous]
        [HttpGet]
        // [Authorize]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();

            return Ok(countries);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> AddCountry([FromBody]Country country)
        {
            await _context.AddAsync(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> RemoveCountry(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

            _context.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}