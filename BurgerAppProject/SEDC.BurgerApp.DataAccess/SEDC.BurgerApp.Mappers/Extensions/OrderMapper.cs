using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Mappers.Extensions
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                FullName = order.FullName,
                Address = order.Address,
                BurgerNames = order.BurgerOrders?.Select(bo => bo.Burger.Name).ToList() ?? new List<string>()
            };
        }

        public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                Location = order.Location,
                FullName = order.FullName,
                BurgersNames = order.BurgerOrders.Select(x => x.Burger.Name).ToList()
            };
        }

        public static OrderViewModel MapToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Location = order.Location,
                IsDelivered = order.IsDelivered,
                LocationId = order.LocationId
            };
        }

    }
}