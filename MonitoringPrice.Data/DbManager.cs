using MonitoringPrice.Data.Interfaces;

namespace MonitoringPrice.Data.Entities.Models
{
    public class DbManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public ICategoryRepository Category { get; set; }
        public ICharacteristicRepository Characteristic { get; set; }
        public IManufacturerRepository Manufacturer { get; set; }
        public IPriceRepository Price { get; set; }
        public IProductRepository Product { get; set; }
        public IRamRepository Ram { get; set; }
        public IUrlRepository Url { get; set; }
        public DbManager(ITextFieldsRepository _textFieldsRepository, 
            IServiceItemsRepository _serviceItemsRepository, 
            ICategoryRepository _categoryRepository, 
            ICharacteristicRepository _characteristicRepository, 
            IManufacturerRepository _manufacturerRepository,
            IPriceRepository _priceRepository,
            IProductRepository _productRepository,
            IRamRepository _ramRepository,
            IUrlRepository _urlRepository
            )
        {
            TextFields = _textFieldsRepository;
            ServiceItems = _serviceItemsRepository;
            Category = _categoryRepository;
            Characteristic = _characteristicRepository;
            Manufacturer = _manufacturerRepository;
            Price = _priceRepository;
            Product = _productRepository;
            Ram = _ramRepository;
            Url = _urlRepository;
        }
    }
}
