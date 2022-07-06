using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Models;
using MonitoringPrice.Web.Models;

namespace MonitoringPrice.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IManufacturerService _manufacturerService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, IManufacturerService manufacturerService, ICategoryService categoryService)
        {
            _productService = productService;
            _manufacturerService = manufacturerService;
            _categoryService = categoryService;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            ViewBag.Manufacturer = await _manufacturerService.GetAllManufacturerFromApi();
            ViewBag.Categories = await _categoryService.GetAllCategoryFromApi();

            var Product = await _productService.GetAllProduct();
            return View(Product);
        }


        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Manufacturer = await _manufacturerService.GetAllManufacturerFromApi();
            ViewBag.Categories = await _categoryService.GetAllCategoryFromApi();

            var model = new ProductModel();

            if (id != 0)
            {
                model = await _productService.GetProductById(id);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Save(ProductModel editModel)
        {
            if (ModelState.IsValid)
            {
                var categoryValue = Request.Form.FirstOrDefault(x => x.Key == "categoryId").Value;
                int.TryParse(categoryValue, out int categoryInt);

                if (categoryInt != 0)
                { 
                    var manufacturerValue = Request.Form.FirstOrDefault(x => x.Key == "manufacturerId").Value;
                    int.TryParse(manufacturerValue, out int manufactureInt);

                    if (manufactureInt != 0)
                    {
                        editModel.ManufacturerId = manufactureInt;
                        editModel.CategoryId = categoryInt;
                        await _productService.Save(editModel);
                    }
                }
            }
            return RedirectToAction("Index");
        }





        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
