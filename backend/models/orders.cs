using System;

#nullable disable

namespace RestaurantOrderingSystem.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }
    }
}
