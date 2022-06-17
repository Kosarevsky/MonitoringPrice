using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Data.Interfaces
{
    public interface IPriceRepository : IRepositoryEntity<Price>
    {
        void Save(Price entity);
    }
}
