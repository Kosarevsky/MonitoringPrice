using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.WebApi.Interfaces;

namespace MonitoringPrice.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _dbManager;

        public HomeController(IUnitOfWork dbManager)
        {
            _dbManager = dbManager;
        }
        public IActionResult Index()
        {
            var aaa = _dbManager.Product.GetAllAsync();
            return View(_dbManager.Product.GetAllAsync());

        }
    }
}
