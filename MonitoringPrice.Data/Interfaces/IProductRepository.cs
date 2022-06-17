using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Data.Interfaces
{
    public interface IProductRepository : IRepositoryEntity<Product>
    {
        void Save(Product entity);
    }
}
