using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.OrderViewModels;


namespace SEDC.BurgerApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the order for editing from your service
            OrderEditViewModel orderEditViewModel = _orderService.GetOrderForEditing(id);
            return View(orderEditViewModel);
        }


        [HttpPost]
        public IActionResult Edit(OrderEditViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.EditOrder(orderViewModel);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    // We can add logs here
                    return View("ExceptionPage");
                }
            }

            // If ModelState is not valid, return the view with validation errors
            return View(orderViewModel);
        }
    }
}
