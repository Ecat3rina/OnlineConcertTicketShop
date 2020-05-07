using System;

namespace ConcertTicketsShop.Dal.Entities
{
    public class Concert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ConcertDate { get; set; }
        public DateTime ConcertStart { get; set; }
        public DateTime ConcertFinish { get; set; }
        public int VenueId { get; set; }
    }
}
