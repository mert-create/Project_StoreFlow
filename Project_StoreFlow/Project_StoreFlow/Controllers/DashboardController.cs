using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            return View();
        }
    }
}
