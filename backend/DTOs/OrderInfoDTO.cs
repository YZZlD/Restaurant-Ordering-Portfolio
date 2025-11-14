#nullable disable

using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.DTOs
{
    public class OrderInfoDTO
    {
        public int OrderInfoId { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
