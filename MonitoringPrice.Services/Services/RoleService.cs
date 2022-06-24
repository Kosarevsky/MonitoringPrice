using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<RoleModel> GetRoleByName(string name)
        {
            var result = _httpClient.GetFromJsonAsync<RoleModel>($"Role/{name}"); //????
            return result;
        }
    }
}
