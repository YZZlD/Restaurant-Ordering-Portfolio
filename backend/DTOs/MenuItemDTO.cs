#nullable disable

namespace RestaurantOrderingSystem.DTOs
{
    /// <summary>
    /// This is just a direct abstraction of the MenuItem model for accessing the menu on the frontend.
    /// </summary>
    public class MenuItemDTO
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public double MenuItemPrice { get; set; }
        public string ImageSource { get; set; }
    }
}
