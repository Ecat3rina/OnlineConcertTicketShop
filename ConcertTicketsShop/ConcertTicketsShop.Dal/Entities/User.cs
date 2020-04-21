using System.Collections.Generic;

namespace ConcertTicketsShop.Dal.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DisplayName { get; set; }

        public List<Ticket> Tickets { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
