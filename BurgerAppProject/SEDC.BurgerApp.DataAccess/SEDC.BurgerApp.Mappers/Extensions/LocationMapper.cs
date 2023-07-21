using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels;
using SEDC.BurgerApp.ViewModels.LocationViewModels.SEDC.BurgerApp.ViewModels;

namespace SEDC.BurgerApp.Mappers
{
    public static class LocationMapper
    {
        public static LocationViewModel MapToViewModel(Location location)
        {
            return new LocationViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                OpensAt = location.OpensAt,
                ClosesAt = location.ClosesAt
            };
        }

        public static Location MapToModel(LocationViewModel locationViewModel)
        {
            return new Location
            {
                Id = locationViewModel.Id,
                Name = locationViewModel.Name,
                Address = locationViewModel.Address,
                OpensAt = locationViewModel.OpensAt,
                ClosesAt = locationViewModel.ClosesAt
            };
        }

        public static Location MapToLocation(LocationViewModel locationViewModel)
        {
            return new Location
            {
                Name = locationViewModel.Name,
                Address = locationViewModel.Address,
                OpensAt = locationViewModel.OpensAt,
                ClosesAt = locationViewModel.ClosesAt
            };
        }
    }
}
