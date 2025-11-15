using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.Repositories
{
    /// <summary>
    /// OrderLineItems only supports adding as you should never directly modify the items within a given order
    /// </summary>
    public class OrderLineItemRepository : IOrderLineItemRepository
    {
        private readonly RestaurantDbContext _context;

        public OrderLineItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderLineItemAsync(OrderLineItem orderLineItem)
        {
            await _context.OrderLineItems.AddAsync(orderLineItem);

            await _context.SaveChangesAsync();
        }
    }
}
