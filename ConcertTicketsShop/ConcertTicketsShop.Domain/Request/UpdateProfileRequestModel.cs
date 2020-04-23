using System.ComponentModel.DataAnnotations;

namespace ConcertTicketsShop.Domain.Request
{
    public class UpdateProfileRequestModel
    {
        [Required]
        public string DisplayName { get; set; }
    }
}
