using SEDC.BurgerApp.Domain.Enums;

namespace SEDC.BurgerApp.Domain.Models
{
    public class Order : BaseEntity
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public bool IsDelivered { get; set; }
        public List<BurgerOrder>? BurgerOrders { get; set; }
        public string? Location { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
