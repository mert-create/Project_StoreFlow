using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.ViewComponents.LayoutComponents
{
    public class _LayoutTodoOnNavbarComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutTodoOnNavbarComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.Where(y=>y.Status==false).OrderBy(x => x.TodoId).Take(5).ToList();
            ViewBag.todoTotalCount = _context.Todos.Count();
            return View(values);
        }
    }
}
