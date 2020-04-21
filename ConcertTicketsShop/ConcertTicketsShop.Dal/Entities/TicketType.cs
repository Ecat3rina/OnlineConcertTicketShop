using System;
using System.Collections.Generic;
using System.Text;

namespace ConcertTicketsShop.Dal.Entities
{
    public class TicketType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public Ticket Ticket { get; set; }
    }
}
