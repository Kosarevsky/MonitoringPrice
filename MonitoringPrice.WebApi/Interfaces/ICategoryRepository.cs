using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Interfaces
{
    public interface ICategoryRepository : IRepositoryEntity<Category>
    {
        void Save(Category entity);
    }
}
