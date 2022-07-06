using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Net.Http.Json;

namespace MonitoringPrice.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;
        public UserService(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
            _client = _httpClientFactory.CreateClient("Price");
        }
        public async Task<UserModel> GetUser(UserModel user)
        {
            //var result = await _httpClient.PostAsJsonAsync<UserModel>($"User/{user}");
            var result = await _client.GetFromJsonAsync<UserModel>($"users/{user.Email}/{user.Password}");
            return result;
        }

        public async Task<HttpResponseMessage> SaveUser(UserModel userModel)
        {
            var user = new
            {
                Email = userModel.Email,
                Password = userModel.Password,
                RoleId = userModel.RoleId,
                Role = userModel.Role
            };
            var result = await _client.PostAsJsonAsync("users", user);
            return result;
        }
    }
}
