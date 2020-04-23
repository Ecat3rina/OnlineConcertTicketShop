using ConcertTicketsShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicketsShop.Dal
{
    public class ConcertTicketsShopDbContext : DbContext
    {
        public ConcertTicketsShopDbContext(DbContextOptions<ConcertTicketsShopDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
