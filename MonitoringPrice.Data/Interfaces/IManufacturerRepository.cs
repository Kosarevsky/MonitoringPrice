using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Data.Interfaces
{
    public interface IManufacturerRepository : IRepositoryEntity<Manufacturer>
    {
        void Save(Manufacturer entity);
    }
}
