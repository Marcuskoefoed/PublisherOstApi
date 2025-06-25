
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherOstApi.Data;
using PublisherOstApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace PublisherOstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumsController : ControllerBase
    {
        private readonly PublisherDbContext _context;
        public AlbumsController(PublisherDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> Get() => await _context.Albums.ToListAsync();

        [HttpGet("bytitle/{title}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetByTitle(string title) =>
            await _context.Albums.Where(a => a.Title.Contains(title)).ToListAsync();
    }
}
