using Microsoft.AspNetCore.Mvc;

namespace frontendApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
