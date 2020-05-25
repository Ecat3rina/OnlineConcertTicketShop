using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Domain.Contract
{
    public interface IWishlistService
    {
        Task AddEventToWishListAsync(WishlistRequestModel request);
        Task DeleteEventFromWishListAsync(WishlistRequestModel request);
        Task<IList<WishlistResponseModel>> GetWishlistitems();
    }
}
