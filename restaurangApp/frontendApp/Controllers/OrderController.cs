using frontendApp.Interfaces;
using frontendApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace frontendApp.Controllers
{
    public class OrderController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7114/api");
        private readonly HttpClient _client;
        private readonly ICartService _cartService;

        public OrderController(ICartService cartService)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            if(cartItems == null || cartItems.Count == 0) 
            {
                ModelState.AddModelError(string.Empty, "Cart is empty.");
                return RedirectToAction("Home", "Index");
            }

            var orderDetails = new OrderViewModel
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(item => item.Price * item.Quantity)
            };
            return View(orderDetails);
        }

        [HttpPost]
        public IActionResult CompleteOrder(OrderViewModel order)
        {
            var cartItems = _cartService.GetCartItems();

            order.OrderNumber = order.OrderNumber;
            order.Name = order.Name;
            order.Phone = order.Phone;
            order.TotalPrice = cartItems.Sum(item => item.Price * item.Quantity);
            order.CartItems = cartItems;

            string data = JsonConvert.SerializeObject(order);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/orders/Create", content).Result;

            if (response.IsSuccessStatusCode)
            {
                _cartService.ClearCart();
                return RedirectToAction("OrderComplete", new { orderNumber = order.OrderNumber, name = order.Name });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while placing the order.");
                return View("Index", order);
            }
        }

        public IActionResult OrderComplete(string orderNumber, string Name)
        {
            // Pass the order number to the view
            ViewBag.OrderNumber = orderNumber;
            ViewBag.Name = Name;

            return View();
        }
    }
}
