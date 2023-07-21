using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp
{
    public class LocationRepo : IRepository<Location>
    {
        public void DeleteById(int id)
        {
            Location location = StaticDb.Locations.FirstOrDefault(l => l.Id == id);
            if (location != null)
            {
                StaticDb.Locations.Remove(location);
            }
        }

        public List<Location> GetAll()
        {
            return StaticDb.Locations;
        }

        public Location GetById(int id)
        {
            return StaticDb.Locations.FirstOrDefault(l => l.Id == id);
        }

        public int Insert(Location entity)
        {
            entity.Id = ++StaticDb.LocationId;
            StaticDb.Locations.Add(entity);
            return entity.Id;
        }

        public void Update(Location entity)
        {
            Location location = StaticDb.Locations.FirstOrDefault(l => l.Id == entity.Id);
            if (location != null)
            {
                location.Name = entity.Name;
                location.Address = entity.Address;
                location.OpensAt = entity.OpensAt;
                location.ClosesAt = entity.ClosesAt;
            }
        }
    }
}
