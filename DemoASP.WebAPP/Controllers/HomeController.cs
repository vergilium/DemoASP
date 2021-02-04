using Microsoft.AspNetCore.Mvc;

namespace DemoASP.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}