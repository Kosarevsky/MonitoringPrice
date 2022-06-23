using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface IUrlRepository : IRepositoryEntity<Url>
    {
        void Save(Url entity);
    }
}
