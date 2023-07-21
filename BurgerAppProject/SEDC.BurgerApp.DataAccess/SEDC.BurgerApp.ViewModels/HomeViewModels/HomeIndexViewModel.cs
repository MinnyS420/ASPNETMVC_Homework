using SEDC.BurgerApp.ViewModels.LocationViewModels.SEDC.BurgerApp.ViewModels;

namespace SEDC.BurgerApp.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public int OrderCount { get; set; }
        public List<string> BurgerIsPopular { get; set; }
        public decimal AverageOrderPrice { get; set; }
        public List<LocationViewModel> Locations { get; set; }
    }
}
