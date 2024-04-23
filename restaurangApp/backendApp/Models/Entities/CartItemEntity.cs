using System.ComponentModel.DataAnnotations;

namespace backendApp.Models.Entities
{
    public class CartItemEntity
    {
        [Key]
        public int Id { get; set; }
        public string DishName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
