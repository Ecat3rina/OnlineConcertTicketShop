using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConcertTicketsShop.Service.Midleware
{
    public class ExceptionHandlingMidleware
    {
        public async Task Invoke(HttpContext httpContext)
        {
            await Task.Run(()=> httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError);
        }
    }
    
}
