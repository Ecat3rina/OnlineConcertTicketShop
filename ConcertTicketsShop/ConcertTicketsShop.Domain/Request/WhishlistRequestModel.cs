using System.ComponentModel.DataAnnotations;

namespace ConcertTicketsShop.Domain.Request
{
    public class WishlistRequestModel
    {
        [Required]
        public int ConcertId { get; set; }
        public int UserId { get; set; }
    }
}
