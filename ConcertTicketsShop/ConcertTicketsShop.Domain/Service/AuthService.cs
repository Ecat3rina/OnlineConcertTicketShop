using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Domain.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthResponseModel> AuthenticateUserAsync(AuthRequestModel request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);

            if(user != null && user.Password == request.Password)
            {
                return new AuthResponseModel
                {
                    DisplayName = user.DisplayName,
                    Token = "HERE IS THE TOKEN"
                };
            }
            return null;
        }
    }
}
