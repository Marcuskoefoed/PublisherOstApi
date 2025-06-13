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
    public class CoversController : ControllerBase
    {
        private readonly PublisherDbContext _context;

        public CoversController(PublisherDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cover>>> GetCovers()
        {
            return await _context.Covers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cover>> GetCover(int id)
        {
            var cover = await _context.Covers.FindAsync(id);

            if (cover == null)
                return NotFound();

            return cover;
        }

        [HttpGet("{id}/artists")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistsByCover(int id)
        {
            var coverArtists = await _context.ArtistCovers
                .Where(ac => ac.CoverId == id)
                .Include(ac => ac.Artist)
                .Select(ac => ac.Artist)
                .ToListAsync();

            if (!coverArtists.Any())
                return NotFound($"No artists found for Cover with ID {id}");

            return Ok(coverArtists);
        }

        [HttpPost]
        public async Task<ActionResult<Cover>> CreateCover(Cover cover)
        {
            _context.Covers.Add(cover);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCover), new { id = cover.CoverId }, cover);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCover(int id, Cover cover)
        {
            if (id != cover.CoverId)
                return BadRequest();

            _context.Entry(cover).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Covers.Any(c => c.CoverId == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCover(int id)
        {
            var cover = await _context.Covers.FindAsync(id);

            if (cover == null)
                return NotFound();

            _context.Covers.Remove(cover);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
