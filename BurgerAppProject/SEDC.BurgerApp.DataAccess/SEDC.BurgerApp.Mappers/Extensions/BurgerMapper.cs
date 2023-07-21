using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.BurgerViewModels;

namespace SEDC.BurgerApp.Mappers.Extensions
{
    public static class BurgerMapper
    {
        public static BurgerIndexViewModel MapToBurgerViewModel(this Burger burger)
        {
            return new BurgerIndexViewModel
            {
                Id = burger.Id,
                Name = burger.Name
            };
        }
        public static BurgerIndexViewModel MapToViewModel(this Burger burger)
        {
            return new BurgerIndexViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                IsPopularBurger = burger.IsPopularBurger,
                HasFries = burger.HasFries,
                Image = $"/images/burgers/{burger.Image}"
            };
        }
        public static Burger MapToBurger(this BurgerIndexViewModel viewModel)
        {
            return new Burger
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price,
                IsVegan = viewModel.IsVegan,
                IsVegetarian = viewModel.IsVegetarian,
                IsPopularBurger = viewModel.IsPopularBurger,
                HasFries = viewModel.HasFries,
            };
        }
    }
}
