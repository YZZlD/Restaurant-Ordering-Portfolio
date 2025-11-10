#nullable disable

namespace RestaurantOrderingSystem.DTOs
{
    public class MenuItemDTO
    {
        public int? Id { get; set;  }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public double MenuItemPrice { get; set; }
    }
}
