using System.Threading.Tasks;
using ConcertTicketsShop.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ConcertTicketsShop.Midleware
{
    public class UnitOfWorkMidleware
    {
        private readonly RequestDelegate _next;
        public UnitOfWorkMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ConcertTicketsShopDbContext dbContext)
        {
            await _next(httpContext);
            await dbContext.SaveChangesAsync();
        }
    }

    public static class UnitOfWorkMidlewareExtension
    {
        public static IApplicationBuilder UseUnitOfWork(this IApplicationBuilder app)
        {
            app.UseMiddleware<UnitOfWorkMidleware>();
            return app;
        }
    }
}
