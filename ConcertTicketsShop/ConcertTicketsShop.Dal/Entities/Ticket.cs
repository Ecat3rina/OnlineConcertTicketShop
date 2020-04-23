namespace ConcertTicketsShop.Dal.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TypeId { get; set; }
        public TicketType Type { get; set; }
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }
    }
}
