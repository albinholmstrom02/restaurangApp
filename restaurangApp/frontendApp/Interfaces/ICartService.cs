using frontendApp.ViewModels;

namespace frontendApp.Interfaces
{
    public interface ICartService
    {
        void AddToCart(DishViewModel dish, int quantity);
        void RemoveFromCart(int id);
        void ClearCart();
        List<CartItemViewModel> GetCartItems();
    }
}
