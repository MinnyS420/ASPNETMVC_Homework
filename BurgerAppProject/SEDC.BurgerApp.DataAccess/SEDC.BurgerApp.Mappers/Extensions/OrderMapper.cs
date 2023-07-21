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
                BurgerNames = order.BurgerOrders.Select(bo => bo.Burger.Name).ToList(),
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                IsDelivered = orderViewModel.IsDelivered,
                BurgerOrders = new List<BurgerOrder>(),
                LocationId = orderViewModel.LocationId,
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
                Id= order.Id,
                Location = order.Location,
                IsDelivered= order.IsDelivered,
                LocationId = order.LocationId
            };
        }
        public static OrderEditViewModel MapToOrderViewModels(this Order order)
        {
            return new OrderEditViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                Location = order.Location
            };
        }
    }
}