using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleModel> GetRoleByName(string name);
    }
}
