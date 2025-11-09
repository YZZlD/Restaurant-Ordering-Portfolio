using System;

#nullable disable

namespace RestaurantOrderingSystem.Models
{
    public partial class Customer
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
