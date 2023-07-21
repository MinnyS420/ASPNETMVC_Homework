namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsDelivered { get; set; }
        public List<string> BurgerNames { get; set; }
    }
}
