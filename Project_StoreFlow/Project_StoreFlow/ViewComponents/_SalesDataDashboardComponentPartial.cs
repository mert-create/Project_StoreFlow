using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;
using Microsoft.EntityFrameworkCore;
namespace Project_StoreFlow.ViewComponents
{
    public class _SalesDataDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;
        public _SalesDataDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Orders.OrderByDescending(z=>z.OrderId).Include(x=>x.Customer).Include(y=>y.Product).Take(5).ToList();
            return View(values);
        }
    }
}
