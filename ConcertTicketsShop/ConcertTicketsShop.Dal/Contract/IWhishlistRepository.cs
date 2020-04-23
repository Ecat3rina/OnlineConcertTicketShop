using ConcertTicketsShop.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Dal.Contract
{
    public interface IWhishlistRepository
    {
        Task<IList<Wishlist>> GetUserWhishlistAsync(int userId);
        Task AddConcertToWhishlistAsync(int userId, int concertId);
       
        //remove ..
    }
}
