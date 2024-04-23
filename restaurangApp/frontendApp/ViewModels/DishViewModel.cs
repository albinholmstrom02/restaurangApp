namespace frontendApp.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public DishType DishType { get; set; }
    }

    public enum DishType
    {
        Pizza = 0,
        Pasta = 1,
        Burger = 2,
        Meat = 3,
    }
}
