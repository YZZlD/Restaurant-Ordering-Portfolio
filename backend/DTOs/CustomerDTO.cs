#nullable disable

namespace RestaurantOrderingSystem.DTOs
{
    public class CustomerDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
