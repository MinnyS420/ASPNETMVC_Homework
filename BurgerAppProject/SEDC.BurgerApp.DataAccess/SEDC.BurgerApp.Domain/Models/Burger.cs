using SEDC.BurgerApp.Domain.Enums;

namespace SEDC.BurgerApp.Domain.Models
{
    public class Burger : BaseEntity
    {
        public string? Name { get; set; }
        public BurgerType BurgerType { get; set; }
        public int Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
        public List<BurgerOrder>? BurgerOrders { get; set; }
    }
}
