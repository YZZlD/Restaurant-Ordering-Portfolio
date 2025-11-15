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

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors();
        }
    }
}
