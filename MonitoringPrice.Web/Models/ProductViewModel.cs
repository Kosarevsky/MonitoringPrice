using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Web.Models
{
    public class ProductViewModel
    {
        public IEnumerable<CategoryModel> CategoryModels { get; set; }
        public IEnumerable<ManufacturerModel> ManufacturerModels { get; set; }
        public IEnumerable<ProductModel> ProductModels { get; set; }
    }
}
