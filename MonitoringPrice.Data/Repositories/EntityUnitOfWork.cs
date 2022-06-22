using MonitoringPrice.Data.Interfaces;


namespace MonitoringPrice.Data.Repositories
{
    public sealed class EntityUnitOfWork :IUnitOfWork
    {
        private readonly AppDbContext _context;
        public EntityUnitOfWork(AppDbContext context)
        {
            _context = context;

        }

        private CategoryRepository _categoryRepository;
        public ICategoryRepository Category => _categoryRepository
                             ?? (_categoryRepository = new CategoryRepository(_context));

        private CharacteristicRepository _characteristicRepository;
        public ICharacteristicRepository Characteristic => _characteristicRepository
                             ?? (_characteristicRepository = new CharacteristicRepository(_context));

        private ManufacturerRepository _manufacturerRepository;
        public IManufacturerRepository Manufacturer => _manufacturerRepository
                             ?? (_manufacturerRepository = new ManufacturerRepository(_context));

        private PriceRepository _priceRepository;
        public IPriceRepository Price => _priceRepository
            ?? (_priceRepository = new PriceRepository(_context));

        private ProductRepository _productRepository;
        public IProductRepository Product => _productRepository
            ?? (_productRepository = new ProductRepository(_context));

        private RamRepository _ramRepository;
        public IRamRepository Ram => _ramRepository
            ?? (_ramRepository = new RamRepository(_context));

        private UrlRepository _urlRepository;
        public IUrlRepository Url => _urlRepository
            ?? (_urlRepository = new UrlRepository(_context));

        private EFServiceItemsRepository _eFServiceItemsRepository;
        public IServiceItemsRepository EFServiceItems => _eFServiceItemsRepository
            ?? (_eFServiceItemsRepository = new EFServiceItemsRepository(_context));
    }
}
