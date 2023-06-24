using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas() 
        {
            var pizzas = StaticDb.Pizzas;

            List<PizzaViewModel> viewModel = pizzas.Select(x => x.ToPizzaListViewModel()).ToList();

            return View(viewModel);
        }

        public IActionResult Details(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction("Error");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(pizza => pizza.Id == id);

            if (pizza == null) 
            {
                return RedirectToAction("Error");
            }

            PizzaViewModel viewModel = pizza.ToPizzaViewModel();
            viewModel.IsOnPromotion = pizza.IsOnPromotion;

            return View(viewModel);
        }

        public IActionResult Error() 
        {
            return View();
        }
    }
}
