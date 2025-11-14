using Microsoft.EntityFrameworkCore;


namespace RestaurantOrderingSystem.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderLineItem>().HasKey(oli => oli.OrderLineItemId);

            builder.Entity<OrderLineItem>().HasOne(oli => oli.Order).WithMany(order => order.OrderLineItems).HasForeignKey(oli => oli.OrderId);

            builder.Entity<OrderLineItem>().HasOne(oli => oli.MenuItem).WithMany(menuItem => menuItem.OrderLineItems).HasForeignKey(oli => oli.MenuItemId);


            base.OnModelCreating(builder);
        }

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderLineItem> OrderLineItems { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
    }
}
