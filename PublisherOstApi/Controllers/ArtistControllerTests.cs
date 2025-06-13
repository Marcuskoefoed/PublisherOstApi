using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherOstApi.Controllers;
using PublisherOstApi.Data;
using PublisherOstApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PublisherOstApi.Tests
{
    public class ArtistControllerTests
    {
        private DbContextOptions<PublisherDbContext> _options;

        public ArtistControllerTests()
        {
            _options = new DbContextOptionsBuilder<PublisherDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            // Seed data
            using (var context = new PublisherDbContext(_options))
            {
                context.Artists.Add(new Artist { ArtistId = 1, Name = "Test Artist 1" });
                context.Artists.Add(new Artist { ArtistId = 2, Name = "Test Artist 2" });
                context.SaveChanges();
            }
        }

        [Fact]
        public async Task GetArtists_ReturnsAllArtists()
        {
            // Arrange
            using var context = new PublisherDbContext(_options);
            var controller = new ArtistsController(context);

            // Act
            var result = await controller.GetArtists();
            var okResult = Assert.IsType<ActionResult<IEnumerable<Artist>>>(result);
            var artists = Assert.IsAssignableFrom<IEnumerable<Artist>>(okResult.Value);

            // Assert
            Assert.Equal(2, ((List<Artist>)artists).Count);
        }

        [Fact]
        public async Task GetArtist_ReturnsArtistById()
        {
            // Arrange
            using var context = new PublisherDbContext(_options);
            var controller = new ArtistsController(context);

            // Act
            var result = await controller.GetArtist(1);
            var okResult = Assert.IsType<ActionResult<Artist>>(result);
            var artist = Assert.IsType<Artist>(okResult.Value);

            // Assert
            Assert.Equal("Test Artist 1", artist.Name);
        }

        [Fact]
        public async Task GetArtist_ReturnsNotFound_WhenIdNotExists()
        {
            // Arrange
            using var context = new PublisherDbContext(_options);
            var controller = new ArtistsController(context);

            // Act
            var result = await controller.GetArtist(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
