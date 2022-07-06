using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProduct();
        Task<ProductModel> GetProductById(int id);
        Task<HttpResponseMessage> Save(ProductModel product);
    }
}