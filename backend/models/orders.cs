namespace RestaurantOrderingSystem.Models
{
    /// <summary>
    /// Orders currently just track completion status and created time and completion time for restaurant use.
    /// Many order line items can be related to an order.
    /// </summary>
    ///
    /// <remarks>
    /// This model can be expanded upon to include fields such as takeout status, customer name, delivery
    /// address etc, however that is beyong the current scope of the project which only targets
    /// the frontend user ordering system.
    /// </remarks>

    public partial class Order
    {
        public int OrderId { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? CompletedTime { get; set; }

        public ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
    }
}
