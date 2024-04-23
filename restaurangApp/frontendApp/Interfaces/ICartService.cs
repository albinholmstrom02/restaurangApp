using frontendApp.ViewModels;

namespace frontendApp.Interfaces
{
    public interface ICartService
    {
        void AddToCart(DishViewModel dish, int quantity);
        void ClearCart();
        List<CartItemViewModel> GetCartItems();
    }
}
