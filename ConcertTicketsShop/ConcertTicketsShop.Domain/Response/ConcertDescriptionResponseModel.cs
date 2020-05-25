using System;
namespace ConcertTicketsShop.Domain.Response
{
    public class ConcertDescriptionResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VenueName { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public bool AddedToWishlist { get; set; }
    }
}
