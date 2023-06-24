using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToPizzaViewModel (this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Name = pizza.Name,
                Price = pizza.Price,
                IsOnPromotion = pizza.IsOnPromotion,
            };
        }
        public static PizzaViewModel ToPizzaListViewModel (this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Name = pizza.Name
            };
        }
    }
}
