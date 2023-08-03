using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILocationService _locationService;
        private readonly IBurgerService _burgerService; // Add this line to inject the IBurgerService

        public OrderController(IOrderService orderService, ILocationService locationService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _locationService = locationService;
            _burgerService = burgerService; // Initialize the IBurgerService
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");

            }
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            // Get the order by its ID from the service
            var order = _orderService.GetOrderById(id);

            // Check if the order exists
            if (order == null)
            {
                return NotFound(); // Return a 404 Not Found view if the order is not found
            }

            try
            {
                // Delete the order
                _orderService.DeleteOrder(id);

                // Redirect to the "Orders" view after successful deletion
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the deletion process
                // You can also display an error message or log the error here
                return View("Error");
            }
        }

    }
}
