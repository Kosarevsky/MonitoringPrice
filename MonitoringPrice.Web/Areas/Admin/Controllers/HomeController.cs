using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.Data.Entities.Models;
using MonitoringPrice.Data.Interfaces;

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
            return View(_dbManager.Product.GetAllAsync());
        }
    }
}
