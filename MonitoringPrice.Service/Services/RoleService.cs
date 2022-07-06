using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Net.Http.Json;

namespace MonitoringPrice.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;
        public RoleService(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
            _client = _httpClientFactory.CreateClient("Price");
        }
        public Task<RoleModel> GetRoleByName(string name)
        {
            var result = _client.GetFromJsonAsync<RoleModel>($"Role/{name}"); //????
            return result;
        }
    }
}
