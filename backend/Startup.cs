using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;
using RestaurantOrderingSystem.Repositories;
using RestaurantOrderingSystem.Services;

namespace RestaurantOrderingSystem
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //We grab the connection string from env variable for production deployment or user_secrets for local development.

            string connectionString = !String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DefaultConnection")) ? Environment.GetEnvironmentVariable("DefaultConnection") : _configuration["ConnectionStrings:DefaultConnection"];


            services.AddMvc();
            services.AddDbContext<RestaurantDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IOrderLineItemRepository, OrderLineItemRepository>();

            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IMenuItemService, MenuItemService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "https://restaurant-ordering-portfolio.onrender.com")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //This was to fix default DateTime behaviour throwing errors within order creation.
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehaviour", true);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors();
        }
    }
}
