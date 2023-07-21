using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess.Repositories.Abstraction
{
    public interface IBurgerRepository : IRepository<Burger>
    {
        Burger GetBurgerIsPopular();
    }
}
