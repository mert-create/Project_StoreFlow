using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;
using Project_StoreFlow.Models;

namespace Project_StoreFlow.ViewComponents
{
    public class _DailySalesDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _DailySalesDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.Todos.GroupBy(t => t.Priority)
                .Select(g => new TodoPriorityChartViewModel
                {
                    Priority = g.Key,
                    Count = g.Count()
                }).ToList();
            return View(data);
        }
    }
}