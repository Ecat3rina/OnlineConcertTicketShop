using System.Threading.Tasks;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicketsShop.Service.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public AuthenticationController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost]
        [Produces(typeof(AuthResponseModel))]
        public async Task<IActionResult> AuthenticateUser(AuthRequestModel request)
        {
            var result = await _authenticationService.AuthenticateUserAsync(request);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}