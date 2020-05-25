using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;


namespace ConcertTicketsShop.Dal.Repository
{
    public class WishlistRepository : BaseRepository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(ConcertTicketsShopDbContext ticketsShopDbContext) : base(ticketsShopDbContext)
        {
        }

        public async Task<IList<Wishlist>> GetUserWhishlistAsync(int userId)
        {
            return await _context.Wishlists.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<Wishlist> GetWhishlistByUserAndConcertIdAsync(int userId, int concertId)
        {
            return await _context.Wishlists.FirstOrDefaultAsync(x => x.UserId == userId && x.ConcertId == concertId);
        }
    }
}
