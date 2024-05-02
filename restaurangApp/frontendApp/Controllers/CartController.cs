using frontendApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace frontendApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) 
        { 
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }
        
        [HttpPost]
        public IActionResult RemoveFromCart(int itemId)
        {
            // Call the service to remove the item from the cart
            _cartService.RemoveFromCart(itemId);

            // Redirect back to the cart page or any other appropriate page
            return RedirectToAction("Index","Cart");
        }
    }
}
