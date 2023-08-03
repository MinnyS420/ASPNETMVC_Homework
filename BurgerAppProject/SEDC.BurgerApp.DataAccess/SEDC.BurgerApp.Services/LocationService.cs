using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.LocationViewModels.SEDC.BurgerApp.ViewModels;

namespace SEDC.BurgerApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _locationRepo;

        public LocationService(IRepository<Location> locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public List<LocationViewModel> GetAllLocations()
        {
            List<Location> locations = _locationRepo.GetAll();
            return locations.Select(location => LocationMapper.MapToViewModel(location)).ToList();
        }

        public LocationViewModel GetLocationById(int id)
        {
            Location location = _locationRepo.GetById(id);
            return LocationMapper.MapToViewModel(location);
        }

        public int AddLocation(LocationViewModel locationViewModel)
        {
            Location location = LocationMapper.MapToLocation(locationViewModel);
            return _locationRepo.Insert(location);
        }

        public void UpdateLocation(LocationViewModel locationViewModel)
        {
            Location location = LocationMapper.MapToLocation(locationViewModel);
            _locationRepo.Update(location);
        }

        public void DeleteLocation(int id)
        {
            _locationRepo.DeleteById(id);
        }
    }
}