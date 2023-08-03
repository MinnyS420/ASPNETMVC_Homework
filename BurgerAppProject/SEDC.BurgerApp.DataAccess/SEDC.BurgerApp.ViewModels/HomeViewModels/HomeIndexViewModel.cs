using SEDC.BurgerApp.ViewModels.LocationViewModels.SEDC.BurgerApp.ViewModels;

namespace SEDC.BurgerApp.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public int OrderCount { get; set; }
        public decimal AverageOrderPrice { get; set; }
        public List<LocationViewModel> Locations { get; set; }
        public string MostOrderedBurger { get; set; }
        public string MostOrderedBurgerImageName { get; set; }
    }
}
