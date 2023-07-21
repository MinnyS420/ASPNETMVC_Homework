using SEDC.BurgerApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Location")]
        public Location Location { get; set; }
        [Display(Name = "User")]
        public int LocationId { get; set; }
    }
}
