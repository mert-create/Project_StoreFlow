using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;
using Project_StoreFlow.Models;

namespace Project_StoreFlow.ViewComponents.DashboardChartComponents
{
    public class _DashboardOrderStatusChartComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _DashboardOrderStatusChartComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var result = _context.Orders.GroupBy(o => o.Status)
                .Select(g => new OrderStatusChartViewModel
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();
            return View(result);
        }
    }
}
