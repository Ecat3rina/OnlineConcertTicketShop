using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;

namespace ConcertTicketsShop.Dal.Repository
{
    public class VenueRepository : BaseRepository<Venue>, IVenueRepository
    {
        public VenueRepository(ConcertTicketsShopDbContext context) : base(context)
        {
        }
    }
}
