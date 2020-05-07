using System.Collections.Generic;
using System.Threading.Tasks;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicketsShop.Service.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("api/venue")]
    public class VenueController : ControllerBase
    {
        public VenueController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Task.FromResult<IList<VenueResponseModel>>(
                new List<VenueResponseModel>
                {
                    new VenueResponseModel
                    {
                        Name = "Sala Palatului",
                        Capacity = 1000
                    }
                }
                ));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateVenue(CreateVenueRequestModel model)
        {
            return Ok(model);
        }
    }
}
