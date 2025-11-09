using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystem;
using RestaurantOrderingSystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
app.MapControllers();
