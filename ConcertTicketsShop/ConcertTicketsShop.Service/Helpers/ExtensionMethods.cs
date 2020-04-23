using System.Linq;
using System.Security.Claims;
namespace ConcertTicketsShop.Service.Helpers
{
    public static class ExtensionMethods
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            var userId = 0;
            var claim = user?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if(claim == null)
            {
                return userId;
            }
            int.TryParse(claim.Value, out userId);
            return userId;
        }
    }
}
