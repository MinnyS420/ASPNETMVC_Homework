using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class BurgerOrderViewModel
    {
        public int OrderId { get; set; }
        [Display(Name = "Burger")]
        public int BurgerId { get; set; }
    }
}
