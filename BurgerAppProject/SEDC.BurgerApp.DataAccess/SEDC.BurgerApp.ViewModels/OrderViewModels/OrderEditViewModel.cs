using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class OrderEditViewModel
    {
        // Add properties relevant to editing an order
        public int Id { get; set; }
        public string FullName { get; set; }
        public Location Location { get; set; }
        public string Address { get; set; }
        public int LocationId { get; set; }
        // Other properties...
    }
}
