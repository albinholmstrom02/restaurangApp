using frontendApp.Interfaces;
using frontendApp.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace frontendApp.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7114/api");
        private readonly HttpClient _client;

        private readonly ICartService _cartService;


        public HomeController(ICartService cartService)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<DishViewModel> dishesList = new List<DishViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/dishes/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                dishesList = JsonConvert.DeserializeObject<List<DishViewModel>>(data);
            }


            return View(dishesList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DishViewModel model = new DishViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/dishes/GetById?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<DishViewModel>(data);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            DishViewModel model = new DishViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/dishes/GetById?id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<DishViewModel>(data);
                _cartService.AddToCart(model, quantity);
            }

            return RedirectToAction("Index");
        }
    }
}
