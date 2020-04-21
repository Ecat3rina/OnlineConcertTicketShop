using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Repository;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertTicketsShop.Service
{
    public static class Dependencies
    {

        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            //repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //services
            services.AddScoped<IAuthService, AuthService>();
            //other
        }
    }
}
