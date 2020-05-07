using System.ComponentModel.DataAnnotations;

namespace ConcertTicketsShop.Domain.Request
{
    public class CreateVenueRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
