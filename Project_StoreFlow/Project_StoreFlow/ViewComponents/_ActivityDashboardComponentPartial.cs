using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.ViewComponents
{
    public class _ActivityDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;
        public _ActivityDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Activities.ToList();
            return View(values);
        }
    }
}
