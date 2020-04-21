using System;
using System.Collections.Generic;
using System.Text;

namespace ConcertTicketsShop.Dal.Entities
{
    public class Concert
    {
        public int Id { get; set; }
        public DateTime ConcertDate { get; set; }
        public DateTime ConcertStart { get; set; }
        public DateTime ConcertFinish { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public List<Artist> Artists { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
