
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherOstApi.Data;
using PublisherOstApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace PublisherOstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class ArtistsController : ControllerBase
    {
        private readonly PublisherDbContext _context;
        public ArtistsController(PublisherDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Get() => await _context.Artists.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> Get(int id) =>
            await _context.Artists.FindAsync(id) is Artist artist ? artist : NotFound();

        [HttpGet("byname/{name}")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetByName(string name) =>
            await _context.Artists.Where(a => a.Name.Contains(name)).ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = artist.ArtistId }, artist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Artist artist)
        {
            if (id != artist.ArtistId) return BadRequest();
            _context.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Artists.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Artists.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
