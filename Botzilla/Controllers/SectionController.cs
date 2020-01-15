using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace Botzilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SectionController(ApplicationDbContext context)
        {
            _context = context;

        }

        // [AllowAnonymous]
        [HttpGet]
        // [Authorize]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Section>>> GetSections()
        {
            var sections = await _context.Sections.ToListAsync();

            return Ok(sections);
        }

        [HttpPost]
        public async Task<ActionResult<Section>> AddSection([FromBody]Section section)
        {
            await _context.AddAsync(section);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Section>> RemoveSection(int id)
        {
            var section = await _context.Sections.FirstOrDefaultAsync(c => c.Id == id);

            _context.Remove(section);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}