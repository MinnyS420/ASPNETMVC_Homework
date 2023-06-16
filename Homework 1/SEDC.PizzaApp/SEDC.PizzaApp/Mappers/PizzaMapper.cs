using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToPizzaViewModel(this Pizza pizza)
        {
            decimal price = pizza.Price;
            if (pizza.HasExtras)
            {
                price += 10;
            }

            return new PizzaViewModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = price,
                PizzaSize = pizza.PizzaSize,
                HasExtras = pizza.HasExtras,
            };
        }
    }
}
