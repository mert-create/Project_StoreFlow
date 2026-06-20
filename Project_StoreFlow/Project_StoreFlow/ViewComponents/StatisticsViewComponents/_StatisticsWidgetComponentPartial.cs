using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsWidgetComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;
        public _StatisticsWidgetComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.ProductMaxPrice = _context.Products.Max(x => x.ProductPrice);
            ViewBag.ProductMinPrice = _context.Products.Min(x => x.ProductPrice);

            ViewBag.productMaxPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Max(y => y.ProductPrice)))
            .Select(z=>z.ProductName).FirstOrDefault();

            ViewBag.productMinPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Min(y => y.ProductPrice)))
            .Select(z=>z.ProductName).FirstOrDefault();

            ViewBag.totalSumProductStock = _context.Products.Sum(x => x.ProductStock);
            ViewBag.avarageProductStock = _context.Products.Average(x => x.ProductStock);
            ViewBag.avarageProductPrice = _context.Products.Average(x => x.ProductPrice);

            ViewBag.biggerPriceThen1000ProductCount=_context.Products.Where(x => x.ProductPrice > 1000).Count();
            ViewBag.getIDIs54ProductName = _context.Products.Where(x => x.ProductId == 54).Select(y => y.ProductName).FirstOrDefault();
            ViewBag.stockCountBıgger50AndSmaller100ProductCount = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();
            
            return View();
        }
    }
}
