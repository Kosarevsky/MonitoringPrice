using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetUser(UserModel user);
        Task<HttpResponseMessage> SaveUser (UserModel user);
    }
}
