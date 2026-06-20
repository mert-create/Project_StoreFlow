using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.ViewComponents
{
    public class _FooterDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
