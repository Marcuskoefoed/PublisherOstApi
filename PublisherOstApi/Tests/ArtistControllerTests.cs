using Xunit;
using PublisherOstApi.Models;

namespace PublisherOstApi
{
    public class ArtistControllerTests
    {
        [Fact]
        public void ArtistModel_StoresDataCorrectly()
        {
            var artist = new Artist { ArtistId = 1, Name = "Test" };
            Assert.Equal("Test", artist.Name);
        }

        [Fact]
        public void Artist_ValidId_ShouldBePositive()
        {
            var artist = new Artist { ArtistId = 5 };
            Assert.True(artist.ArtistId > 0);
        }

        [Fact]
        public void Artist_Name_ShouldNotBeNull()
        {
            var artist = new Artist { Name = "ABC" };
            Assert.NotNull(artist.Name);
        }
    }
}
