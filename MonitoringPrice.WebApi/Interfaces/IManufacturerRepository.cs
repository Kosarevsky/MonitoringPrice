using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface IManufacturerRepository : IRepositoryEntity<Manufacturer>
    {
        Task<int> SaveAsync(Manufacturer entity);
    }
}
