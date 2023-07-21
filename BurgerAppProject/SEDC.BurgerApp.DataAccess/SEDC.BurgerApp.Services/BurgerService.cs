using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers.Extensions;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.BurgerViewModels;

namespace SEDC.BurgerApp.Services
{
    public class BurgerService : IBurgerService
    {

        private IBurgerRepository _burgerRepo;

        public BurgerService (IBurgerRepository burgerRepo)
        {
            _burgerRepo = burgerRepo;
        }

        public List<string> GetBurgerIsPopular()
        {
            List<Burger> burgersDb = _burgerRepo.GetAll();
            return burgersDb
                .Where(b => b.IsPopularBurger)
                .Select(b => b.Name)
                .ToList();
        }

        public List<BurgerIndexViewModel> GetBurgersFromDropdown()
        {
            List<Burger> burgersDb = _burgerRepo.GetAll();
            return burgersDb.Select(b => b.MapToBurgerViewModel()).ToList();
        }

        public List<BurgerIndexViewModel> GetAllBurgers()
        {
            List<Burger> burgersDb = _burgerRepo.GetAll();
            return burgersDb.Select(b => b.MapToViewModel()).ToList();
        }
    }
}