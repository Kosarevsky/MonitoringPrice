using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Net.Http.Json;

namespace MonitoringPrice.Services.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly HttpClient _httpClient;
        public ManufacturerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Delete(int id)
        {
            var response = _httpClient.DeleteAsync($"Manufacturers/{id}");
            return response;
        }

        public async Task<IEnumerable<ManufacturerModel>> GetAllManufacturerFromApi()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<ManufacturerModel>>("Manufacturers");
            //var json = JsonSerializer.Deserialize<IEnumerable<ManufacturerModel>>(response);
            return response;
        }

        public async Task<ManufacturerModel> GetManufactyrerById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ManufacturerModel>($"Manufacturers/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> Save(ManufacturerModel manufacturer)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Manufacturers",manufacturer);
            return response;
        }
    }
}
