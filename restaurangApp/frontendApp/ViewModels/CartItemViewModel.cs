namespace frontendApp.ViewModels
{
    public class CartItemViewModel
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
