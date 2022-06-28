using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProduct();
    }
}