namespace PublisherOstApi.Models
{
    public class ArtistCover
    {
        public int ArtistId { get; set; }
        public int CoverId { get; set; }

        // Navigation Properties
        public Artist Artist { get; set; } = null!;
        public Cover Cover { get; set; } = null!;
    }
}
