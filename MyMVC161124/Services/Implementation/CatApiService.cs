using MyMVC161124.Models;
using MyMVC161124.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MyMVC161124.Services.Implementation
{
    public class CatApiService : ICatApiService
    {
        private readonly HttpClient? _httpClient;
        private readonly string _apiKey = "live_CF4XppcEgPoMVe4o6Dfw8nDLJP25wHc6fKshGA0ZyxJTy3ZRCQLH4FumfbT7XsLF";
        private readonly string _apiUrl = "https://api.thecatapi.com/v1/images/search";
        private readonly IWebHostEnvironment _env;

        public CatApiService(HttpClient httpClient, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
            _env = env;
        }

        async Task<List<Cat>> ICatApiService.GetCatsAsync(int count)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}?limit={count}");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadFromJsonAsync<List<Cat>>();
                if (responseContent is null)
                {
                    throw new InvalidOperationException($"Received an empty jsonData from the {nameof(_httpClient)}");
                }

                return responseContent;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"{nameof(HttpRequestException)} occured while trying to retrieve cats. {ex.Message}");
                throw new ServiceException("I couldn't connect to the cat factory! :(", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unknown error occured while trying to retrieve cats. {ex.Message}");
                throw new ServiceException("Something happened and I'm not sure what... :(", ex);
            }
        }

        async Task<List<Cat>> ICatApiService.GetSampleCatsAsync(int count)
        {//Data/cat_temp_data.json
            var fileDirectory = Path.Combine(_env.ContentRootPath, "Data", "cat_temp_data.json");

            if (!File.Exists(fileDirectory))
            {
                throw new FileNotFoundException($"File: {fileDirectory} does not exist");
            }

            var jsonData = await File.ReadAllTextAsync(fileDirectory);
            var deserializedJson = JsonSerializer.Deserialize<List<Cat>>(jsonData);
            var listOfCats = deserializedJson.Take(count).ToList();

            return listOfCats;
        }

        public class ServiceException : Exception
        {
            public ServiceException(string message, Exception innerException) : base(message, innerException) { }
        }
    }
}
