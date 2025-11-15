#nullable disable

using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.DTOs
{
    /// <summary>
    /// The DTO for OrderInfo is a combination of MenuItem objects linked through orderline items
    /// to represent all information that could possibly currently be needed. It gives all
    /// the MenuItems within an order.
    /// </summary>
    public class OrderInfoDTO
    {
        public int OrderInfoId { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }

        public IEnumerable<MenuItemDTO> MenuItems { get; set; }
    }
}
