using System.Threading.Tasks;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Service.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicketsShop.Service.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(UpdateProfileRequestModel updateProfileRequest)
        {
            var userId = User.GetId();
            await _profileService.UpdateProfileAsync(userId, updateProfileRequest);
            return Ok();
        }
    }
}
