namespace RestaurantOrderingSystem.Models
{
    /// <summary>
    /// MenuItems have an image source to access within the static files of the frontend.
    /// </summary>
    ///
    /// <remarks>
    /// MenuItems has a one to many relationship with OrderLineItems as a single MenuItem can be present
    /// among many OrderLineItems.
    /// </remarks>

    public partial class MenuItem
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public double MenuItemPrice { get; set; }
        public string ImageSource { get; set; }

        public ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
    }
}
