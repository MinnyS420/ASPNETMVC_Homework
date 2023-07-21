using SEDC.BurgerApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Order Location")]
        public Location Location { get; set; }
        [Display(Name = "User")]
        public string FullName { get; set; }
        [Display(Name = "Burgers")]
        public List<string> BurgersNames { get; set; }
        public int Id { get; set; }
    }
}
