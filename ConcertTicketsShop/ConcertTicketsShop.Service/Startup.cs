using System.Text;
using ConcertTicketsShop.Dal;
using ConcertTicketsShop.Domain.Configuration;
using ConcertTicketsShop.Midleware;
using ConcertTicketsShop.Service.Midleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ConcertTicketsShop.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //database
            var dbOptions = new DbConnectionStringsOptions();
            Configuration.GetSection("ConnectionStrings").Bind(dbOptions);

            var authOptions = new AuthOptions();
            Configuration.GetSection("Authentication").Bind(authOptions);

            services.AddDbContext<ConcertTicketsShopDbContext>(options =>
                options.UseSqlServer(dbOptions.ConcertTicketsShopConnectionString), ServiceLifetime.Scoped);

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials());
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false,
                   ValidateIssuer = true,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authOptions.EncryptionKey)),
                   ValidIssuer = authOptions.Issuer
               };
           });

            //dependecies
            Dependencies.RegisterDependencies(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //add exception handling
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ExceptionHandlingMidleware().Invoke
                
            });

            //commit business transactions
            app.UseUnitOfWork();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
