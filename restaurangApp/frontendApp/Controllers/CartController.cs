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
            _cartService.RemoveFromCart(itemId);

            return RedirectToAction("Index","Cart");
        }
    }
}
