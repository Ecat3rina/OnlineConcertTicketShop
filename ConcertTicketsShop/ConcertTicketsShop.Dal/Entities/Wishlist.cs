﻿namespace ConcertTicketsShop.Dal.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ConcertId { get; set; }
    }
}
