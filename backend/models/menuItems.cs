using System;

#nullable disable

namespace RestaurantOrderingSystem.Models
{
    public partial class MenuItem
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public double MenuItemPrice { get; set; }

        public int OrderLineItemId { get; set; }
        public OrderLineItem OrderLineItems { get; set; }
    }
}
