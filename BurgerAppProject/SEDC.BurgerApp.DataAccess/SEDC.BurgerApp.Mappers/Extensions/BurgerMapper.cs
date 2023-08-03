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
                HasFries = burger.HasFries,
                Image = $"/images/burgers/{burger.ImageName}"
            };
        }
        public static Burger MapToBurger(BurgerIndexViewModel viewModel)
        {
            return new Burger
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price,
                IsVegan = viewModel.IsVegan,
                IsVegetarian = viewModel.IsVegetarian,
                HasFries = viewModel.HasFries
            };
        }

        public static Burger MapToModel(this BurgerCreateViewModel viewModel)
        {
            return new Burger
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                IsVegan = viewModel.IsVegan,
                IsVegetarian = viewModel.IsVegetarian,
                HasFries = viewModel.HasFries
            };
        }
        public static BurgerEditViewModel MapToEditViewModel(Burger burger)
        {
            return new BurgerEditViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                HasFries = burger.HasFries
            };
        }
        public static BurgerCreateViewModel MapToCreateViewModel(this Burger burger)
        {
            return new BurgerCreateViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                HasFries = burger.HasFries
            };
        }

        public static Burger MapToBurger(BurgerCreateViewModel burgerViewModel)
        {
            return new Burger
            {
                Id = burgerViewModel.Id,
                Name = burgerViewModel.Name,
                Price = burgerViewModel.Price,
                IsVegan = burgerViewModel.IsVegan,
                IsVegetarian = burgerViewModel.IsVegetarian,
                HasFries = burgerViewModel.HasFries
            };
        }
    }
}
