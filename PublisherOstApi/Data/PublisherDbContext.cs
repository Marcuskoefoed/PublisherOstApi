
using Microsoft.EntityFrameworkCore;
using PublisherOstApi.Models;

namespace PublisherOstApi.Data
{
    public class PublisherDbContext : DbContext
    {
        public PublisherDbContext(DbContextOptions<PublisherDbContext> options) : base(options) {}

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<ArtistCover> ArtistCovers { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistCover>()
                .HasKey(ac => new { ac.ArtistId, ac.CoverId });
        }
    }
}
