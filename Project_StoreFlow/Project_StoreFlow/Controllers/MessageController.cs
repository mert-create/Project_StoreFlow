using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.Controllers
{
    public class MessageController : Controller
    {
        private readonly StoreContext _context;

        public MessageController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values = _context.Messages.AsNoTracking().ToList();
            return View(values);
        }
    }
}
