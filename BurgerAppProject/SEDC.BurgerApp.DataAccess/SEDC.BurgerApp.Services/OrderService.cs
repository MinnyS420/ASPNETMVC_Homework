using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers.Extensions;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepo;
        private IRepository<Location> _locationRepo;
        private IBurgerRepository _burgerRepo;

        public OrderService(IRepository<Order> orderRepo, 
                            IRepository<Location> locationRepo, 
                            IBurgerRepository burgerRepo)
        {
            _orderRepo = orderRepo;
            _locationRepo = locationRepo;
            _burgerRepo = burgerRepo;
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            List<Order> dbOrders = _orderRepo.GetAll();
            return dbOrders.Select(order => order.MapToOrderListViewModel()).ToList();
        }

        public void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel)
        {
            var burgerDb = _burgerRepo.GetById(burgerOrderViewModel.BurgerId);
            if (burgerDb == null)
            {
                throw new Exception($"Burger with id {burgerOrderViewModel.BurgerId} was not found");
            }

            var orderDb = _orderRepo.GetById(burgerOrderViewModel.OrderId);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {burgerOrderViewModel.OrderId} was not found");
            }

            var burgerOrder = new BurgerOrder
            {
                Burger = burgerDb,
                BurgerId = burgerDb.Id,
                Order = orderDb,
                OrderId = orderDb.Id
            };

            orderDb.BurgerOrders.Add(burgerOrder);

            _orderRepo.Update(orderDb);
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            Location locationDb = _locationRepo.GetById(orderViewModel.LocationId);

            if (locationDb == null)
            {
                throw new Exception($"User with id {orderViewModel.LocationId} was not found!");
            }

            Order order = orderViewModel.MapToOrder();
            order.Location = locationDb;

            int newOrderId = _orderRepo.Insert(order);
            if (newOrderId <= 0)
            {
                throw new Exception("An error occured while saving to db");
            }
        }

        public void DeleteOrder(int id)
        {
            Order orderDb = _orderRepo.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            _orderRepo.DeleteById(id);
        }

        public void EditOrder(OrderEditViewModel orderViewModel)
        {
            Order orderDb = _orderRepo.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {orderViewModel.Id} was not found!");
            }

            Location locationDb = _locationRepo.GetById(orderViewModel.LocationId);
            if (locationDb == null)
            {
                throw new Exception($"The location with id {orderViewModel.LocationId} was not found!");
            }
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            Order orderDb = _orderRepo.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            return orderDb.MapToOrderDetailsViewModel();
        }

        public OrderEditViewModel GetOrderForEditing(int id)
        {
            Order orderDb = _orderRepo.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            return orderDb.MapToOrderViewModels();
        }

        public decimal GetAverageOrderPrice()
        {
            List<Order> orders = StaticDb.Orders;
            if (orders.Count == 0)
            {
                return 0; // Return 0 if there are no orders to avoid division by zero.
            }

            decimal totalOrderPrice = (decimal)orders.Sum(order => order.BurgerOrders.Sum(burgerOrder => burgerOrder.Burger.Price));
            decimal averagePrice = totalOrderPrice / orders.Count;

            return averagePrice;
        }

    }
}
