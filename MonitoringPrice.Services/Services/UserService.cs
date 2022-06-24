using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserModel> GetUserByEmail(string email)
        {
            var result = await _httpClient.GetFromJsonAsync<UserModel>($"User/{email}");
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
            var result = await _httpClient.PostAsJsonAsync("user", user);
            return result;
        }
    }
}
