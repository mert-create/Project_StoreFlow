using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.ViewComponents
{
    public class _CardStatisticsDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;
        public _CardStatisticsDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.totalCustomerCount = _context.Customers.Count();
            ViewBag.totalCategoryCount = _context.Categories.Count();
            ViewBag.totalProductCount = _context.Products.Count();
            if (_context.Customers.Any())
            {
                ViewBag.avgCustomersBalance = Math.Round(_context.Customers.Average(x => x.CustomerBalance), 2);
            }
            else
            {
                ViewBag.avgCustomersBalance = 0;
            }
            ViewBag.totalOrderCount = _context.Orders.Count();
            if (_context.Orders.Any())
            {
                ViewBag.sumOrderProductCount = _context.Orders.Sum(x => x.OrderCount);
            }
            else
            {
                ViewBag.sumOrderProductCount = 0;
            }
            return View();
        }   
    }
}
