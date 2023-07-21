using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Services;
using SEDC.BurgerApp.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IRepository<Order>, OrderRepo>();
builder.Services.AddTransient<IRepository<Location>, LocationRepo>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddTransient<IBurgerRepository, BurgerRepo>();
builder.Services.AddScoped<IBurgerService, BurgerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();