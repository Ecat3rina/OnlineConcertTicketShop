using System.Collections;
using System.Collections.Generic;

namespace ConcertTicketsShop.Domain.Response
{
    public class AuthResponseModel
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
    }
}
