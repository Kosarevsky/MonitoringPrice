using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using System.Net.Http.Json;

namespace MonitoringPrice.Services.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserModel> GetUser(UserModel user)
        {
            //var result = await _httpClient.PostAsJsonAsync<UserModel>($"User/{user}");
            var result = await _httpClient.GetFromJsonAsync<UserModel>($"users/{user.Email}/{user.Password}");
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
            var result = await _httpClient.PostAsJsonAsync("users", user);
            return result;
        }
    }
}
