using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Net.Http.Json;

namespace MonitoringPrice.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;
        public CategoryService(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
            _client = _httpClientFactory.CreateClient("Price");
        }

        public Task DeleteCategory(int id)
        {
            var response = _client.DeleteAsync($"Category/{id}");
            return response;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoryFromApi()
        {
            var response = await _client.GetFromJsonAsync<IEnumerable<CategoryModel>>("Category");
            return response;
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var response = await _client.GetFromJsonAsync<CategoryModel>($"Category/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> SaveCategory(CategoryModel category)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("Category", category);
            return response;
        }
    }
}
