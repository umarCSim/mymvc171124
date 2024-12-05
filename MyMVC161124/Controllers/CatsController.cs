using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyMVC161124.Models;
using MyMVC161124.Services.Interfaces;

namespace MyMVC161124.Controllers
{
    public class CatsController : Controller
    {
        private readonly ILogger<CatsController> _logger;
        private readonly ICatApiService _catApiService;

        private List<CatImages> _catImages;

        public CatsController(ILogger<CatsController> logger, ICatApiService catApiService)
        {
            _logger = logger;
            _catApiService = catApiService;
        }

        public async Task<IActionResult> Index()
        {
            var pageSize = 10;

            //Bank images
            if (_catImages.IsNullOrEmpty())
            {
                _catImages = await _catApiService.GetListOfCatImagesAsync(pageSize);
            }

            return View(_catImages);
        }

        public async void GetMoreImagesAsync(int pageSize)
        {
            _catImages.AddRange(await _catApiService.GetListOfCatImagesAsync(pageSize));
        }
    }
}
