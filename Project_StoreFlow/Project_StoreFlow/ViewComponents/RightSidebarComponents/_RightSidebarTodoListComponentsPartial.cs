using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.ViewComponents.RightSidebarComponents
{
    public class _RightSidebarTodoListComponentsPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarTodoListComponentsPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values =_context.Todos.OrderBy(x=>x.TodoId).ToList().TakeLast(15).ToList();
            return View(values);
        }
    }
}
