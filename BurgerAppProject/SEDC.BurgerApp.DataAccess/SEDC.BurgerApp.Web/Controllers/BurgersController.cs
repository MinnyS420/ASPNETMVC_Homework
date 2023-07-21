using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Services.Abstractions;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class BurgersController : Controller
    {
        private readonly IBurgerService _burgerService;

        public BurgersController(IBurgerService burgerService)
        {
            _burgerService = burgerService;
        }

        public IActionResult Index()
        {
            var burgers = _burgerService.GetAllBurgers();
            return View(burgers);
        }
    }
}
