#nullable disable

using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.DTOs
{
    public class OrganizationOrderDTO
    {
        public int? Id { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        public bool Takeout { get; set; }

        public MenuItem MenuItem { get; set; }
        public Customer Customer { get; set; }
    }
}
