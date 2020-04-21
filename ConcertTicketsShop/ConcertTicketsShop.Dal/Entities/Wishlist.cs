using System;
using System.Collections.Generic;
using System.Text;

namespace ConcertTicketsShop.Dal.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Concert> Concerts { get; set; }
    }
}
