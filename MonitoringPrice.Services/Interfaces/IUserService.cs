using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetUserByEmail (string id);
        Task<HttpResponseMessage> SaveUser (UserModel user);
    }
}
