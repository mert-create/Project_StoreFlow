using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_StoreFlow.Context;
using Project_StoreFlow.Entities;
using Project_StoreFlow.Models;

namespace Project_StoreFlow.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;
        public OrderController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult AllStockSmollerThen5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount <= 5);
            if (orderStockCount == true)
            {
                ViewBag.v = "Tüm siparişlerin stok adedi 5'ten küçüktür.";
            }
            else
            {
                ViewBag.v = "Tüm siparişlerin stok adedi 5'ten küçüktür değildir.";
            }
            return View();
        }
        public IActionResult OrderListByStatus(string status)
        {
            var values = _context.Orders.Where(x => x.Status.Contains(status)).ToList();
            if (!values.Any())
            {
                ViewBag.v = "Bu statüde veri bulunmamaktadır.";
            }
            return View(values);
        }
        public IActionResult OrderListSearch(string name, string FilterType)
        {
            if (FilterType == "start")
            {
                var values = _context.Orders.Where(x => x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if (FilterType == "end")
            {
                var values = _context.Orders.Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);
            }
            var ordervalues = _context.Orders.ToList();
            return View(ordervalues);

        }
        public async Task<IActionResult> OrderList()
        {
            var values = await _context.Orders.Include(x => x.Product).Include(y => y.Customer).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var products = await _context.Products.
               Select(p => new SelectListItem
               {
                   Value = p.ProductId.ToString(),
                   Text = p.ProductName.ToString()
               }).ToListAsync();
            ViewBag.Products = products;

            var customers = await _context.Customers.
               Select(c => new SelectListItem
               {
                   Value = c.CustomerId.ToString(),
                   Text = c.CustomerName + " " + c.CustomerSurname
               }).ToListAsync();
            ViewBag.customers = customers;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Sipariş Alındı";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var value = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(value);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var products = await _context.Products.
               Select(p => new SelectListItem
               {
                   Value = p.ProductId.ToString(),
                   Text = p.ProductName.ToString()
               }).ToListAsync();
            ViewBag.Products = products;

            var customers = await _context.Customers.
               Select(c => new SelectListItem
               {
                   Value = c.CustomerId.ToString(),
                   Text = c.CustomerName + " " + c.CustomerSurname
               }).ToListAsync();
            ViewBag.customers = customers;
            var value = await _context.Orders.FindAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        public IActionResult OrderListWithCustomerGroup()
        {
            var result = from customer in _context.Customers
                         join order in _context.Orders
                         on customer.CustomerId equals order.CustomerId
                         into orderGroup
                         select new CustomerOrderViewModel
                         {
                             CustomerName = customer.CustomerName+ " "+customer.CustomerSurname,
                             Orders = orderGroup.ToList()
                         };
            return View(result.ToList());
        }

    }
}
