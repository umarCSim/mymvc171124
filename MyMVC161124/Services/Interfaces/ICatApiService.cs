using MyMVC161124.Models;

namespace MyMVC161124.Services.Interfaces
{
    public interface ICatApiService
    {
        Task<List<Cat>> GetCatsAsync(int count = 5);
        Task<List<Cat>> GetSampleCatsAsync(int count = 5);
    }
}
