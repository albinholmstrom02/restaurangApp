using frontendApp.Interfaces;
using frontendApp.ViewModels;

namespace frontendApp.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItemViewModel> _cartItems = new List<CartItemViewModel>();

        public void AddToCart(DishViewModel dish, int quantity)
        {
            var existingCartItem = _cartItems.FirstOrDefault(item => item.Id == dish.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItemViewModel
                {
                    Id = dish.Id,
                    DishName = dish.Name,
                    ImageUrl = dish.ImageUrl,
                    Price = dish.Price,
                    Quantity = quantity
                });
            }
        }

        public void RemoveFromCart(int id)
        {
            var itemToRemove = _cartItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                _cartItems.Remove(itemToRemove);
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public List<CartItemViewModel> GetCartItems()
        {
            return _cartItems;
        }
    }
}
