using System;

#nullable disable

namespace RestaurantOrderingSystem.Models
{
    public partial class MenuItem
    {
        public int ID { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public double MenuItemPrice { get; set; }
    }
}
