using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherOstApi.Data;
using PublisherOstApi.Models;
using System.Threading.Tasks;

namespace PublisherOstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistCoversController : ControllerBase
    {
        private readonly PublisherDbContext _context;

        public ArtistCoversController(PublisherDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AssignCoverToArtist(ArtistCover artistCover)
        {
            if (!_context.Artists.Any(a => a.ArtistId == artistCover.ArtistId) ||
                !_context.Covers.Any(c => c.CoverId == artistCover.CoverId))
            {
                return BadRequest("Invalid Artist or Cover ID.");
            }

            _context.ArtistCovers.Add(artistCover);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
