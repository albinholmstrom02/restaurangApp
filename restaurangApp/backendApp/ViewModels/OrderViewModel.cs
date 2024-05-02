using backendApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace backendApp.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        public List<CartItemEntity> CartItems { get; set; }
    }
}
