using SEDC.BurgerApp.ViewModels.LocationViewModels.SEDC.BurgerApp.ViewModels;

namespace SEDC.BurgerApp.Services.Abstractions
{
    public interface ILocationService
    {
        List<LocationViewModel> GetAllLocations();
        LocationViewModel GetLocationById(int id);
        int AddLocation(LocationViewModel locationViewModel);
        void UpdateLocation(LocationViewModel locationViewModel);
        void DeleteLocation(int id);
    }
}
