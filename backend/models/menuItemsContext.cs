using Microsoft.EntityFrameworkCore;

namespace RestaurantOrderingSystem.Models;

public class MenuItemsContext : DbContext
{
    public MenuItemsContext(DbContextOptions<MenuItemsContext> options) : base(options)
    {

    }

    public DbSet<MenuItem> MenuItems { get; set; } = null!;
}
