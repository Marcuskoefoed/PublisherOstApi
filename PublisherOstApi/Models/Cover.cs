namespace PublisherOstApi.Models
{
    public class Cover
    {
        public int CoverId { get; set; }
        public string Title { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<ArtistCover> ArtistCovers { get; set; } = new List<ArtistCover>();
    }
}
