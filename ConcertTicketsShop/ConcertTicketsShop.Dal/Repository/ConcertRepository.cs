using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;

namespace ConcertTicketsShop.Dal.Repository
{
    public class ConcertRepository : BaseRepository<Concert>, IConcertRepository
    {
        public ConcertRepository(ConcertTicketsShopDbContext context) : base(context)
        {
        }
    }
}
