using System.Threading.Tasks;
using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;

namespace ConcertTicketsShop.Domain.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;

        public ProfileService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UpdateProfileAsync(int userId, UpdateProfileRequestModel updateProfileRequest)
        {
            var user = await _userRepository.GetById(userId);
            user.DisplayName = updateProfileRequest.DisplayName;
            _userRepository.Update(user);
        }
    }
}
