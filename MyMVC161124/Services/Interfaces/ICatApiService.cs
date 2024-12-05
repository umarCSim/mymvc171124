using MyMVC161124.Models;

namespace MyMVC161124.Services.Interfaces
{
    public interface ICatApiService
    {
        public Task<List<CatImages>> GetListOfCatImagesAsync(int count = 5);

    }
}
