using Microsoft.AspNetCore.Mvc;

namespace web_javascript_connection.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateSupplier()
        {
            return View();
        }
    }
}
