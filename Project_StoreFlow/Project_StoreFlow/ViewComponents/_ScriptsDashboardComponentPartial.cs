using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.ViewComponents
{
    public class _ScriptsDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
