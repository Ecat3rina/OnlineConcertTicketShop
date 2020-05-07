using ConcertTicketsShop.Dal.Contract;
using ConcertTicketsShop.Dal.Repository;
using ConcertTicketsShop.Domain.Configuration;
using ConcertTicketsShop.Domain.Contract;
using ConcertTicketsShop.Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConcertTicketsShop.Service
{
    public static class Dependencies
    {

        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            //options
            services.Configure<AuthOptions>(configuration.GetSection("Authentication"));
            services.Configure<DbConnectionStringsOptions>(configuration.GetSection("ConnectionStrings"));
            //repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IConcertRepository, ConcertRepository>();
            services.AddScoped<IWhishlistRepository, WhishlistRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRolesRepository, UserRoleRepository>();

            //services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IConcertService, ConcertService>();
            //other
        }
    }
}
