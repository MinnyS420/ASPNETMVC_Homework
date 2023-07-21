using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Services.Abstractions
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderDetails(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        OrderEditViewModel GetOrderForEditing(int id);
        void EditOrder(OrderEditViewModel orderViewModel);
        void DeleteOrder(int id);
        void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel);
        decimal GetAverageOrderPrice();
    }
}