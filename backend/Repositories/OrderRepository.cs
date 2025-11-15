using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _context;

        public OrderRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            Order order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);

                await _context.SaveChangesAsync();
            }
        }
    }
}
