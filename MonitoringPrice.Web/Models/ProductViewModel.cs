using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Web.Models
{
    public class ProductViewModel
    {
        IEnumerable<CategoryModel> CategoryModels { get; set; }
        IEnumerable<ManufacturerModel> ManufacturerModels { get; set; }
        IEnumerable<ProductModel> ProductModels { get; set; }
    }
}
