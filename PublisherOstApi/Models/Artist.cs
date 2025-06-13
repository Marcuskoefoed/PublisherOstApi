namespace PublisherOstApi.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ArtistCover> ArtistCovers { get; set; } = new List<ArtistCover>();
    }
}
