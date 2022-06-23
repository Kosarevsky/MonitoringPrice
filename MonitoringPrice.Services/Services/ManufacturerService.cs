using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Text.Json;

namespace MonitoringPrice.Services.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly HttpClient _httpClient;
        public ManufacturerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ManufacturerModel>> GetAllManufacturerFromApi()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<ManufacturerModel>>("Manufacturers");
            //var json = JsonSerializer.Deserialize<IEnumerable<ManufacturerModel>>(response);
            return response;
        }
    }
}
