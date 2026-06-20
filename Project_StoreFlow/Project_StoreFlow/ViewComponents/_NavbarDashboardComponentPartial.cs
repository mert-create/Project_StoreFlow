using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.ViewComponents
{
    public class _NavbarDashboardComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
