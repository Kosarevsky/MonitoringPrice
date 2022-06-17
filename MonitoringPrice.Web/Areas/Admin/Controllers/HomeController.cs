using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.Data.Entities.Models;

namespace MonitoringPrice.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DbManager _dbManager;

        public HomeController(DbManager dbManager)
        {
            _dbManager = dbManager;
        }
        public IActionResult Index()
        {
            return View(_dbManager.Product.GetAll());
        }
    }
}
