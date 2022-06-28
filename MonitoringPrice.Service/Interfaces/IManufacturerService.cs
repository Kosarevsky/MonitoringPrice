using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerModel>> GetAllManufacturerFromApi();
        Task<ManufacturerModel> GetManufactyrerById(int id);
        Task<HttpResponseMessage> Save(ManufacturerModel manufacturer);
        Task Delete(int id);
    }
}
