﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;

namespace ConcertTicketsShop.Dal.Repository
{
    public class WhishlistRepository : BaseRepository<Wishlist>, IWhishlistRepository
    {
        public WhishlistRepository(ConcertTicketsShopDbContext ticketsShopDbContext) : base(ticketsShopDbContext)
        {
        }

        public async Task<IList<Wishlist>> GetUserWhishlistAsync(int userId)
        {
            return await Task.FromResult(_context.Wishlists.Where(x => x.UserId == userId).ToList());
        }
    }
}