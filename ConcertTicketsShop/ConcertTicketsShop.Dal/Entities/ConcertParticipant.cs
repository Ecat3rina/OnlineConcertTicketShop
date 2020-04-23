namespace ConcertTicketsShop.Dal.Entities
{
    public class ConcertParticipant
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public int ArtistId { get; set; }
    }
}
