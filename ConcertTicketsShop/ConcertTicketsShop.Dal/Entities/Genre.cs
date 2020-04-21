using System;
using System.Collections.Generic;
using System.Text;

namespace ConcertTicketsShop.Dal.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public Artist Artist { get; set; }
    }
}
