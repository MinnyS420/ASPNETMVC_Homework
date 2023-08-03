using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Services.Abstractions
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        Order GetOrderById(int id);
        OrderDetailsViewModel GetOrderDetails(int id);
        void DeleteOrder(int id);
        void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel);
        decimal GetAverageOrderPrice();
        string GetMostOrderedBurger();
        string GetMostOrderedBurgerImageName();
    }
}