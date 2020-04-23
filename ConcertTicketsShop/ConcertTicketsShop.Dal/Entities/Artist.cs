namespace ConcertTicketsShop.Dal.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
