using Microsoft.AspNetCore.Mvc;
using MyMVC161124.Services.Interfaces;

namespace MyMVC161124.Controllers
{
    public class CatsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatApiService _catApiService;

        public CatsController(ILogger<HomeController> logger, ICatApiService catApiService)
        {
            _logger = logger;
            _catApiService = catApiService;
        }

        public async Task<IActionResult> Index()
        {
            var pageSize = 10;

            var cats = await _catApiService.GetCatsAsync(pageSize);
            return View(cats);
        }
    }
}
