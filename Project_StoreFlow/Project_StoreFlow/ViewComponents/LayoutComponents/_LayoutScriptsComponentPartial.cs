using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.ViewComponents.LayoutComponents
{
    public class _LayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
