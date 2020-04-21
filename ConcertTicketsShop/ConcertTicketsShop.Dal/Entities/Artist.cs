using System;
using System.Collections.Generic;
using System.Text;

namespace ConcertTicketsShop.Dal.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }
    }
}
