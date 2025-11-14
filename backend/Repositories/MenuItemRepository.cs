using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;

namespace RestaurantOrderingSystem.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantDbContext _context;

        public MenuItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsByOrderId(int id)
        {
            var query = from order in _context.Set<Order>()
                        join orderLineItem in _context.Set<OrderLineItem>() on order.OrderLineItemId equals orderLineItem.OrderLineItemId
                        join menuItem in _context.Set<MenuItem>() on orderLineItem.MenuItemId equals menuItem.MenuItemId
                        where order.OrderId == id
                        select menuItem;

            List<MenuItem> menuItems = query.ToList<MenuItem>();

            return menuItems;

        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            MenuItem MenuItems = await _context.MenuItems.FindAsync(id);

            if (MenuItems != null)
            {
                _context.MenuItems.Remove(MenuItems);

                await _context.SaveChangesAsync();
            }
        }
    }
}
