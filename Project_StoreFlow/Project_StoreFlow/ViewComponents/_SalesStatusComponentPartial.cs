using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;
using Project_StoreFlow.Models;

namespace Project_StoreFlow.ViewComponents
{
    public class _SalesStatusComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _SalesStatusComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.Customers.GroupBy(x => x.CustomerCity)
                .Select(g => new CustomerCityChartViewModel
                {
                    City = g.Key,
                    Count = g.Count()
                }).ToList();
            return View(data);
        }
    }
}
