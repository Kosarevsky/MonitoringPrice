using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerModel>> GetAllManufacturerFromApi();
    }
}
