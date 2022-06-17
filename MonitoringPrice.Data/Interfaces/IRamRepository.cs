using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Data.Interfaces
{
    public interface IRamRepository : IRepositoryEntity<Ram>
    {
        void Save(Ram entity);
    }
}
