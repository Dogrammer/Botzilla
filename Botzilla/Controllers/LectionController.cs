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
    public class LectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LectionController(ApplicationDbContext context)
        {
            _context = context;

        }

        // [AllowAnonymous]
        [HttpGet]
        // [Authorize]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Lection>>> GetLections()
        {
            var lections = await _context.Lections.ToListAsync();

            return Ok(lections);
        }

        [HttpPost]
        public async Task<ActionResult<Lection>> AddLection([FromBody]Lection lection)
        {
            await _context.AddAsync(lection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Lection>> RemoveLection(int id)
        {
            var lection = await _context.Lections.FirstOrDefaultAsync(c => c.Id == id);

            _context.Remove(lection);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}