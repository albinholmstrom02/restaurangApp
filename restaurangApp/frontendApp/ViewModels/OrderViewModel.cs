using System.ComponentModel.DataAnnotations;

namespace frontendApp.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public int TotalPrice { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }

        public OrderViewModel()
        {
            OrderNumber = GenerateOrderNumber();
            CartItems = new List<CartItemViewModel>();
        }
        private string GenerateOrderNumber()
        {
            Random random = new Random();

            int number1 = random.Next(0, 9);
            int number2 = random.Next(0, 9);
            int number3 = random.Next(0, 9);

            char char1 = (char)random.Next('A', 'Z' + 1);
            char char2 = (char)random.Next('A', 'Z' + 1);
            char char3 = (char)random.Next('A', 'Z' + 1);

            string orderNumber = $"{number1}{number2}{number3}{char1}{char2}{char3}";

            return orderNumber;
        }
    }
}
