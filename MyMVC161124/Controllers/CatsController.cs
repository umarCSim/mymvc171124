using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using MyMVC161124.Models;
using MyMVC161124.Services.Interfaces;
using System.Collections.Generic;

namespace MyMVC161124.Controllers
{
    public class CatsController(ILogger<CatsController> _logger, ICatApiService _catApiService) : Controller
    {
        private List<CatImages> _catImages;

        public async Task<IActionResult> Index()
        {
            var pageSize = 10;

            _catImages = _catImages.IsNullOrEmpty()
                ? await FetchImagesAsync(pageSize)
                : _catImages;

            return View(_catImages);
        }

        public async Task<List<CatImages>> FetchImagesAsync(int pageSize) =>
            await _catApiService.GetListOfCatImagesAsync(pageSize);

    }
}
