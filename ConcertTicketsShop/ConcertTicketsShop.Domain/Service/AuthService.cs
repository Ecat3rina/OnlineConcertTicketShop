using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;
using ConcertTicketsShop.Domain.Configuration;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ConcertTicketsShop.Domain.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRolesRepository _userRolesRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly AuthOptions _authOptions;
        public AuthService(IOptions<AuthOptions> authOptions,
            IUserRepository userRepository,
            IUserRolesRepository userRolesRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _userRolesRepository = userRolesRepository;
            _roleRepository = roleRepository;
            _authOptions = authOptions.Value;
        }

        public async Task<AuthResponseModel> AuthenticateUserAsync(AuthRequestModel request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);

            if(user != null && user.Password == request.Password)
            {
                return new AuthResponseModel
                {
                    DisplayName = user.DisplayName,
                    Token = await GenerateJwtToken(user)
                };
            }
            return null;
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authOptions.EncryptionKey);

            var userRoles = await GetUserRoles(user.Id);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            claims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Issuer = _authOptions.Issuer,
                Expires = DateTime.UtcNow.AddDays(_authOptions.TokenLifetimeInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(securityToken);
            return jwtToken;
        }

        private async Task<IList<string>> GetUserRoles(int userId)
        {
            var roles = (await _roleRepository.GetAll()).ToDictionary(x => x.Id);
            var userRoles = await _userRolesRepository.GetUserRoles(userId);
            if (!userRoles.Any())
            {
                userRoles.Add(new UserRole
                {
                    RoleId = 1,
                });
            }
            return userRoles.Select(x => roles[x.RoleId].Name).ToList();
        }
    }
}
