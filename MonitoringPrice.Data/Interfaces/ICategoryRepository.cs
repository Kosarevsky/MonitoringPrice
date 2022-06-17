using MonitoringPrice.Data.Entities.Models;



namespace MonitoringPrice.Data.Interfaces
{
    public interface ICategoryRepository : IRepositoryEntity<Category>
    {
        void Save(Category entity);
    }
}
