using System;

#nullable disable

namespace RestaurantOrderingSystem.Models
{
    public partial class Order
    {
        public int ID { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        public bool Takeout { get; set; }

        public MenuItem MenuItem { get; }
        public Customer Customer { get; set; }
    }
}
