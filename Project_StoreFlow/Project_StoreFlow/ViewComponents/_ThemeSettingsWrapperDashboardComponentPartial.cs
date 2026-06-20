using Microsoft.AspNetCore.Mvc;

namespace Project_StoreFlow.ViewComponents
{
    public class _ThemeSettingsWrapperDashboardComponentPartial:ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
