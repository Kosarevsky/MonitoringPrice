using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Data.Interfaces
{
    public interface IUrlRepository : IRepositoryEntity<Url>
    {
        void Save(Url entity);
    }
}
