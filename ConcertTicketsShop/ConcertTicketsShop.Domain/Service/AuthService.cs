﻿using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Entities;
using ConcertTicketsShop.Domain.Configuration;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Request;
using ConcertTicketsShop.Domain.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Domain.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthOptions _authOptions;
        public AuthService(IUserRepository userRepository, IOptions<AuthOptions> authOptions)
        {
            _userRepository = userRepository;
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
                    Token = GenerateJwtToken(user)
                };
            }
            return null;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authOptions.EncryptionKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

                }),
                Issuer = _authOptions.Issuer,
                Expires = DateTime.UtcNow.AddDays(_authOptions.TokenLifetimeInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(securityToken);
            return jwtToken;
        }
    }
}
