using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;

namespace ConcertTicketsShop.Dal.Repository
{
    public class RoleRepository : BaseRepository<Role> , IRoleRepository
    {
        public RoleRepository(ConcertTicketsShopDbContext context) : base(context) { }
    }
}
