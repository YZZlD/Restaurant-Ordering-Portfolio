namespace RestaurantOrderingSystem.Models
{
    public partial class OrderLineItem
    {
        public int OrderLineItemId { get; set; }

        //Setting up foreign key relationship for Orders
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        //Setting up foreign key relationship for MenuItems
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;
    }
}
