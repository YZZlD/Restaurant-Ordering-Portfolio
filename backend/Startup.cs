using System;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem.Models;

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

            services.AddDbContext<OrdersContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddDbContext<MenuItemsContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddDbContext<CustomersContext>(options =>
                options.UseNpgsql(connectionString));
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
