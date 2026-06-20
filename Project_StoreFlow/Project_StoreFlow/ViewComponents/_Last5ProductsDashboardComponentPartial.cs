using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.ViewComponents
{
    public class _Last5ProductsDashboardComponentPartial : ViewComponent
    {
        public StoreContext _context;

        public _Last5ProductsDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Products.OrderBy(p => p.ProductId).ToList().SkipLast(5).ToList().TakeLast(6).ToList();
            return View(values);
        }
    }
}
