using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategoryFromApi();
        Task<CategoryModel> GetCategoryById(int id);
        Task<HttpResponseMessage> SaveCategory(CategoryModel category);
        Task DeleteCategory(int id);
    }
}
