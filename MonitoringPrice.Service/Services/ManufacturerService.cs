using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MonitoringPrice.Services.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client; 
        public ManufacturerService(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
             _client = _httpClientFactory.CreateClient("Price");
        }

        public Task Delete(int id)
        {
            var response = _client.DeleteAsync($"Manufacturers/{id}");
            return response;
        }

        public async Task<IEnumerable<ManufacturerModel>> GetAllManufacturerFromApi()
        {
            var response = await _client.GetFromJsonAsync<IEnumerable<ManufacturerModel>>("Manufacturers");
            return response;
        }

        public async Task<ManufacturerModel> GetManufactyrerById(int id)
        {
            var response = await _client.GetFromJsonAsync<ManufacturerModel>($"Manufacturers/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> Save(ManufacturerModel manufacturer)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("Manufacturers",manufacturer);
            return response;
        }
    }
}
