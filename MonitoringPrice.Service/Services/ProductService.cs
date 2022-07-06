using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Net.Http.Json;

namespace MonitoringPrice.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;
        public ProductService(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
            _client = _httpClientFactory.CreateClient("Price");
        }

        public async Task<IEnumerable<ProductModel>> GetAllProduct()
        {
            var result = await _client.GetFromJsonAsync<IEnumerable<ProductModel>>("Products");
            return result;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var response = await _client.GetFromJsonAsync<ProductModel>($"Products/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> Save(ProductModel product)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync<ProductModel>("Products", product);
            return response;
        }
    }
}
