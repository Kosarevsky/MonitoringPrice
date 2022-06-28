using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;

namespace MonitoringPrice.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryModel> bbb = await _categoryService.GetAllCategoryFromApi();
            return View(bbb);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = id == default ? new CategoryModel() : await _categoryService.GetCategoryById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Save(CategoryModel manufacturer)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.SaveCategory(manufacturer);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
