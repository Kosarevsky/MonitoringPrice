using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IManufacturerService _manufacturerService;

        public HomeController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ManufacturerModel> bbb = await _manufacturerService.GetAllManufacturerFromApi();
            return View(bbb);

        }
    }
}
