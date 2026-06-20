using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_StoreFlow.Context;
using Project_StoreFlow.Entities;
using Project_StoreFlow.Models;


namespace Project_StoreFlow.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult ProductList()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var Categories = _context.Categories.
                Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName.ToString()
                }).ToList();
            ViewBag.Categories = Categories;
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var Categories = _context.Categories.
                Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName.ToString()
                }).ToList();
            ViewBag.Categories = Categories;

            var value = _context.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public IActionResult First5ProductList()
        {
            var values = _context.Products.Include(x => x.Category).Take(5).ToList();
            return View(values);
        }
        public IActionResult Skip4ProductList()
        {
            var values = _context.Products.Include(x => x.Category).Skip(4).Take(10).ToList();
            return View(values);
        }

        public IActionResult CreateProductWithAttach()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductWithAttach(Product product)
        {
            var category = new Category { CategoryId = 1 };
            _context.Categories.Attach(category);
            var productvalue = new Product
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStock = product.ProductStock,
                Category = category
            };
            _context.Products.Add(productvalue);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public IActionResult ProductCount()
        {
            var value = _context.Products.LongCount();
            var lastproduct = _context.Products.OrderBy(x => x.ProductId).Last();
            ViewBag.v2 = lastproduct.ProductName;
            ViewBag.v = value;
            return View();
        }
        public IActionResult ProductListWithCategory()
        {
            var result = from c in _context.Categories
                         join p in _context.Products
                         on c.CategoryId equals p.CategoryId
                         select new ProductWithCategoryViewModel
                         {
                             ProductName = p.ProductName,
                             ProductStock = p.ProductStock,
                             CategoryName = c.CategoryName
                         };
            return View(result.ToList());
        }
        
    }
}
