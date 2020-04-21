using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Domain.Contract
{
    public interface IAuthService
    {
        Task<AuthResponseModel> AuthenticateUserAsync(AuthRequestModel request);
    }
}
