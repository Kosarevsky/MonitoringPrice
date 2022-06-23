using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface IRamRepository : IRepositoryEntity<Ram>
    {
        void Save(Ram entity);
    }
}
