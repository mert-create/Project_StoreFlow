using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_StoreFlow.Context;
using Project_StoreFlow.Entities;
using Project_StoreFlow.Models;

namespace Project_StoreFlow.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;
        public CustomerController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x => x.CustomerName).ThenBy(y => y.CustomerSurname).ToList();
            return View(values);
        }
        public IActionResult CustomerListOrderByDesc()
        {
            var values = _context.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(values);
        }
        public IActionResult CustomerGetByCity(string city)
        {
            var exist = _context.Customers.Any(x => x.CustomerCity == city);
            if (exist)
            {
                ViewBag.message = $"{city} şehrinde en az 1 tane müşteri var.";
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok.";
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _context.Customers.
                ToList().GroupBy(x => x.CustomerCity).ToList();
            return View(groupedCustomers);
        }
        public IActionResult CustomersByCityCount()
        {
            var query = from c in _context.Customers
                        group c by c.CustomerCity into
                        cityGroup
                        select new CustomerCityGroup
                        {
                            City = cityGroup.Key,
                            CustomerCount = cityGroup.Count()
                        };
            var model = query.ToList();
            return View(model);
        }
        public IActionResult CustomersCityList()
        {
            var values = _context.Customers.Select(x => x.CustomerCity).Distinct().ToList();
            return View(values);
        }
        public IActionResult ParallelCustomers()
        {
            var customers = _context.Customers.ToList();
            var results = customers.AsParallel().Where(x => x.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase)).
            ToList();
            return View(results);
        }
        public IActionResult CustomerListExceptCityInİstanbul()
        {
            var allCustomers = _context.Customers.ToList();
            var customerListinİstanbul = _context.Customers
                .Where(x => x.CustomerCity == "İstanbul").ToList();
            var result = allCustomers.Except(customerListinİstanbul).ToList();
            return View(result);
        }
        public IActionResult CustomerListWithDefaultIfEmpty()
        {
            var custoners = _context.Customers.Where(x => x.CustomerCity == "Ankara").ToList().DefaultIfEmpty(new Customer
            {
                CustomerId = 0,
                CustomerName = "Mert",
                CustomerSurname = "Çolak",
                CustomerCity = "Ankara"
            }).ToList();
            return View(custoners);
        }
        public IActionResult CustomerIntersectByCity()
        {
            var cityvalues1 = _context.Customers.Where(x => x.CustomerCity == "İstanbul")
                .Select(y => y.CustomerName + " " + y.CustomerSurname).ToList();
            var cityvalues2 = _context.Customers.Where(x=>x.CustomerCity =="Ankara")
                .Select(y=>y.CustomerName+" " + y.CustomerSurname).ToList();
            var ıntersectvalues=cityvalues1.Intersect(cityvalues2).ToList();

            return View(ıntersectvalues);
        }
        public IActionResult CustomerCastExample()
        {
            var values = _context.Customers.ToList();
            ViewBag.v= values;
            return View();
        }
        public IActionResult CustomerListWithIndex()
        {
            var customers = _context.Customers.ToList()
                .Select((c, index) => new
                {
                    SiraNo = index + 1,
                    c.CustomerName,
                    c.CustomerSurname,
                    c.CustomerCity,
                }).ToList();
            return View(customers);
        }
    }
}
