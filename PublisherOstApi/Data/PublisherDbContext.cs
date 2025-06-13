using Microsoft.EntityFrameworkCore;
using PublisherOstApi.Models;

namespace PublisherOstApi.Data
{
    public class PublisherDbContext : DbContext
    {
        public PublisherDbContext(DbContextOptions<PublisherDbContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<ArtistCover> ArtistCovers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the composite key for the ArtistCover entity
            modelBuilder.Entity<ArtistCover>()
                .HasKey(ac => new { ac.ArtistId, ac.CoverId });

            modelBuilder.Entity<ArtistCover>()
                .HasOne(ac => ac.Artist)
                .WithMany(a => a.ArtistCovers)
                .HasForeignKey(ac => ac.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArtistCover>()
                .HasOne(ac => ac.Cover)
                .WithMany(c => c.ArtistCovers)
                .HasForeignKey(ac => ac.CoverId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Artists
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Artist One" },
                new Artist { ArtistId = 2, Name = "Artist Two" },
                new Artist { ArtistId = 3, Name = "Artist Three" }
            );

            // Seed Covers
            modelBuilder.Entity<Cover>().HasData(
                new Cover { CoverId = 1, Title = "Cover One" },
                new Cover { CoverId = 2, Title = "Cover Two" }
            );

            // Seed ArtistCovers (AFTER Artists and Covers are seeded)
            modelBuilder.Entity<ArtistCover>().HasData(
                new ArtistCover { ArtistId = 1, CoverId = 1 },
                new ArtistCover { ArtistId = 1, CoverId = 2 },
                new ArtistCover { ArtistId = 2, CoverId = 1 }
            );
        }
    }
}
