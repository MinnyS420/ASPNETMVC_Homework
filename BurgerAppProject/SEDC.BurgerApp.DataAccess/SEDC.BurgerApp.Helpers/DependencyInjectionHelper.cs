using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.Services;
using Microsoft.Extensions.DependencyInjection;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp;

namespace SEDC.BurgerApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            // static db
            services.AddTransient<IRepository<Order>, OrderRepo>();
            services.AddTransient<IBurgerRepository, BurgerRepo>();

        }

    }
}
