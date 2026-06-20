using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.ViewComponents
{
    public class _RightSidebarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
