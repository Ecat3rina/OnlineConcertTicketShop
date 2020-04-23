using System;
using System.Threading.Tasks;
using ConcertTicketsShop.Domain.Request;

namespace ConcertTicketsShop.Domain.Contract
{
    public interface IProfileService
    {
        Task UpdateProfileAsync(int userId, UpdateProfileRequestModel updateProfileRequest);
    }
}
