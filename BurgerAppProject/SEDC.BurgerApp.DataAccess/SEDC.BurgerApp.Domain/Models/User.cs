namespace SEDC.BurgerApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public List<Order> Orders { get; set; }
    }
}
