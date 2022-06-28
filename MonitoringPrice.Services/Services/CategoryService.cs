using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task DeleteCategory(int id)
        {
            var response = _httpClient.DeleteAsync($"Category/{id}");
            return response;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoryFromApi()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryModel>>("Category");
            return response;
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CategoryModel>($"Category/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> SaveCategory(CategoryModel category)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Category", category);
            return response;
        }
    }
}
