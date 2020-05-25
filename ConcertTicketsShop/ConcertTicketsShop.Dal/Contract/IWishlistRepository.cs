using ConcertTicketsShop.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Contract
{
    public interface IWishlistRepository : IBaseRepository<Wishlist>
    {
        Task<IList<Wishlist>> GetUserWhishlistAsync(int userId);
        Task<Wishlist> GetWhishlistByUserAndConcertIdAsync(int userId, int concertId);

    }
}
