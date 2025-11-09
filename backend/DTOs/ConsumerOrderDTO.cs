#nullable disable

using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.DTOs
{
    public class ConsumerOrderDTO
    {
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }

        public MenuItem MenuItem { get; set; }
    }
}
