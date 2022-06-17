using Microsoft.AspNetCore.Mvc;
using MonitoringPrice.Web.Models;

namespace MonitoringPrice.Web.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            //string[] source = { "Cash", "Check", "Credit Card" };
            //SelectList selectList = new SelectList(source, source[0]);
            //ViewBag.SelectItems = selectList;

            return View(new PaymentQueryViewModel());
        }

        [HttpPost]
        public IActionResult Index(PaymentQueryViewModel model)
        {
            //string[] source = { "Cash", "Check", "Credit Card" };
            //SelectList selectList = new SelectList(source, source[0]);
            //ViewBag.SelectItems = selectList;
            return View(model);
        }
    }
}
