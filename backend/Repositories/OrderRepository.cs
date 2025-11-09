using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;

//TODO: THIS IS A GENERIC IMPLEMENTATION OF ACCESSING THE ORDER TABLE FROM THE DATABASE THIS WILL CHANGE LATER FOR MORE SPECIFIC QUERIES

namespace RestaurantOrderingSystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext _context;

        public OrderRepository(OrdersContext context)
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
