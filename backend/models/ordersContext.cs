using Microsoft.EntityFrameworkCore;

namespace RestaurantOrderingSystem.Models;

public class OrdersContext : DbContext
{
    public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; } = null!;
}
