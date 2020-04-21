using System.ComponentModel.DataAnnotations;

namespace ConcertTicketsShop.Domain.Request
{
    public class AuthRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
