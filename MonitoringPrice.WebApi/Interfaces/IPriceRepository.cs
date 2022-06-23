using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface IPriceRepository : IRepositoryEntity<Price>
    {
        void Save(Price entity);
    }
}
