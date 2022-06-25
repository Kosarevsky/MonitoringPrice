using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ManufacturerModel> bbb = await _manufacturerService.GetAllManufacturerFromApi();
            return View(bbb);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = id == default ? new ManufacturerModel() : await _manufacturerService.GetManufactyrerById(id);
            return View(model);
        }
    }
}
