using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers;
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
        private ILocationService _locationService;
        private IBurgerService _burgerService;

        public OrderService(IRepository<Order> orderRepo,
                            IRepository<Location> locationRepo,
                            IBurgerRepository burgerRepo,
                            ILocationService locationService,
                            IBurgerService burgerService)
        {
            _orderRepo = orderRepo;
            _locationRepo = locationRepo;
            _burgerRepo = burgerRepo;
            _locationService = locationService;
            _burgerService = burgerService;
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            List<OrderListViewModel> orderListViewModels = new List<OrderListViewModel>();

            foreach (var order in StaticDb.Orders)
            {
                var orderViewModel = order.MapToOrderListViewModel();
                orderViewModel.Address = order.Address;
                orderViewModel.Location = LocationMapper.MapToViewModel(order.Location);
                orderViewModel.BurgerNames = order.BurgerOrders.Select(bo => bo.Burger.Name).ToList();
                orderListViewModels.Add(orderViewModel);
            }
            return orderListViewModels;
        }

        public Order GetOrderById(int id)
        {
            // Get the order from the repository by its ID
            Order orderDb = _orderRepo.GetById(id);

            // If the order with the given ID is not found, return null or throw an exception as per your requirements
            if (orderDb == null)
            {
                // You can choose to return null or throw an exception
                // For this example, I'm throwing a custom exception
                throw new ArgumentException($"Order with ID {id} not found.");
            }

            // Return the order
            return orderDb;
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
        public void DeleteOrder(int id)
        {
            Order orderDb = _orderRepo.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            _orderRepo.DeleteById(id);
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
        public string GetMostOrderedBurger()
        {
            List<Order> orders = _orderRepo.GetAll();
            var groupedBurgers = orders
                .SelectMany(order => order.BurgerOrders)
                .GroupBy(bo => bo.Burger.Name)
                .OrderByDescending(group => group.Count());

            string mostOrderedBurger = groupedBurgers.FirstOrDefault()?.Key ?? "No burgers";
            return mostOrderedBurger;
        }
        public string GetMostOrderedBurgerImageName()
        {
            List<Order> orders = _orderRepo.GetAll();
            var groupedBurgers = orders
                .SelectMany(order => order.BurgerOrders)
                .GroupBy(bo => bo.Burger.Name)
                .OrderByDescending(group => group.Count());

            string mostOrderedBurgerImageName = groupedBurgers.FirstOrDefault()?.FirstOrDefault()?.Burger?.Name.Replace(" ", "")?.ToLower();
            return mostOrderedBurgerImageName;
        }
    }
}