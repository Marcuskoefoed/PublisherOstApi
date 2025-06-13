using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherOstApi.Data;
using PublisherOstApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherOstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly PublisherDbContext _context;

        public ArtistsController(PublisherDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
                return NotFound();

            return artist;
        }

        [HttpGet("{id}/covers")]
        public async Task<ActionResult<IEnumerable<Cover>>> GetCoversByArtist(int id)
        {
            var artistCovers = await _context.ArtistCovers
                .Where(ac => ac.ArtistId == id)
                .Include(ac => ac.Cover)
                .Select(ac => ac.Cover)
                .ToListAsync();

            if (!artistCovers.Any())
                return NotFound($"No covers found for Artist with ID {id}");

            return Ok(artistCovers);
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArtist), new { id = artist.ArtistId }, artist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId)
                return BadRequest();

            _context.Entry(artist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Artists.Any(a => a.ArtistId == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
                return NotFound();

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
