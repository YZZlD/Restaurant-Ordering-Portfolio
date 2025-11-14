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
            //Grabbing connection string from local secret keys
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];


            services.AddMvc();
            services.AddDbContext<RestaurantDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IMenuItemService, MenuItemService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
        }
    }
}
