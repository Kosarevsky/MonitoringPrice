namespace MonitoringPrice.Services.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        /// <summary>Id Производителя</summary>
        public int ManufacturerId { get; set; }

        /// <summary>Производитель</summary>
        //public ManufacturerModel Manufacturer { get; set; }

        /// <summary>Id Категории</summary>
        public int CategoryId { get; set; }
        //public CategoryModel Category { get; set; }

        //public ICollection<Ram> RamItems { get; set; }
    }
}
