using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
