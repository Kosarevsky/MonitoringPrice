using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface IProductRepository : IRepositoryEntity<Product>
    {
        void Save(Product entity);
    }
}
