using System.ComponentModel.DataAnnotations;

namespace frontendApp.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public int TotalPrice { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }

        public OrderViewModel()
        {
            CartItems = new List<CartItemViewModel>();
        }
    }
}
