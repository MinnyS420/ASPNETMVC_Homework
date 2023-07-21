using SEDC.BurgerApp.ViewModels.BurgerViewModels;
using SEDC.BurgerApp.ViewModels.HomeViewModels;

namespace SEDC.BurgerApp.Services.Abstractions
{
    public interface IBurgerService
    {
        List<BurgerIndexViewModel> GetBurgersFromDropdown();
        List<string> GetBurgerIsPopular();
        List<BurgerIndexViewModel> GetAllBurgers();
    }
}
