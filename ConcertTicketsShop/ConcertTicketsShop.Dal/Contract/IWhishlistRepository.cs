using ConcertTicketsShop.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Contract
{
    public interface IWhishlistRepository : IBaseRepository<Wishlist>
    {
        Task<IList<Wishlist>> GetUserWhishlistAsync(int userId);
    }
}
