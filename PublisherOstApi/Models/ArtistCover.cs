using PublisherOstApi.Models;

public class ArtistCover
{
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }     

    public int CoverId { get; set; }
    public Cover Cover { get; set; }      
}
