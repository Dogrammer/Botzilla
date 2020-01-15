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
    public class ArticleController : ControllerBase

    {
        private readonly ApplicationDbContext _context;
        public ArticleController(ApplicationDbContext context)
        {
            _context = context;

        }

        // [AllowAnonymous]
        [HttpGet]
        // [Authorize]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            var articles = await _context.Articles.ToListAsync();

            return Ok(articles);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> AddArticle([FromBody]Article article)
        {
            await _context.AddAsync(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> RemoveCountry(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(c => c.Id == id);

            _context.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}