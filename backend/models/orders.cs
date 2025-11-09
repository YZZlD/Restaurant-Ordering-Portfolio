using System;

#nullable disable

namespace RestaurantOrderingSystem.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        public bool Takeout { get; set; }

        //Linking the MenuItem and Customer tables for foreign key relationships.
        public MenuItem MenuItem { get; }
        public Customer Customer { get; set; }
    }
}
