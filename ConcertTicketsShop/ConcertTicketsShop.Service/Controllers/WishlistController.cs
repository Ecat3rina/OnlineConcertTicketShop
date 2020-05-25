using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Service;
using ConcertTicketsShop.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Service.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("api/whishlist")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;
        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }
        [HttpPost]
        public async Task<IActionResult> AddEventToWishList(WishlistRequestModel request)
        {
            request.UserId = User.GetId();
            await _wishlistService.AddEventToWishListAsync(request);
            return Ok();
        }
        [HttpDelete("{concertId}")]
        public async Task<IActionResult> DeleteAddEventFromWishList(int concertId)
        {
           
            await _wishlistService.DeleteEventFromWishListAsync(new WishlistRequestModel
            {
                ConcertId = concertId,
                UserId = User.GetId()
            });
            return Ok();
        }
    }
}
