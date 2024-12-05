using MyMVC161124.Models;

namespace MyMVC161124.Services.Interfaces
{
    public interface ICatApiService
    {
        Task<List<CatImages>> GetCatsAsync(int count = 5);
        Task<List<CatImages>> GetSampleCatsAsync(int count = 5);
    }
}
