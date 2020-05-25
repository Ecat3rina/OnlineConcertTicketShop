using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Domain.Service
{
    public class WishlistService:IWishlistService
    {
        private readonly IWishlistRepository _whishlistRepository;
        public WishlistService(IWishlistRepository whishlistRepository)
        {
            _whishlistRepository = whishlistRepository;
        }

        public async Task AddEventToWishListAsync(WishlistRequestModel wishlistRequestModel)
        {
            var existingEntity = await _whishlistRepository
                .GetWhishlistByUserAndConcertIdAsync(wishlistRequestModel.UserId, wishlistRequestModel.ConcertId);
            if (existingEntity != null) return;
            await _whishlistRepository.Create(new Dal.Entities.Wishlist
            {
                ConcertId = wishlistRequestModel.ConcertId,
                UserId = wishlistRequestModel.UserId
            });
        }
        public async Task DeleteEventFromWishListAsync(WishlistRequestModel wishlistRequestModel)
        {
            var entityToDelete = await _whishlistRepository.GetWhishlistByUserAndConcertIdAsync(wishlistRequestModel.UserId, wishlistRequestModel.ConcertId);
            _whishlistRepository.Delete(entityToDelete);
        }

        public async Task<IList<WishlistResponseModel>> GetWishlistitems()
        {
            var items = await _whishlistRepository.GetAll();

            return items.Select(x => new WishlistResponseModel
            {
                Id = x.Id
            }).ToList();
        }
    }
}
