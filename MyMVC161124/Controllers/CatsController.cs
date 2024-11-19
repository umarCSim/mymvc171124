using Microsoft.AspNetCore.Mvc;

namespace MyMVC161124.Controllers
{
    public class CatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
