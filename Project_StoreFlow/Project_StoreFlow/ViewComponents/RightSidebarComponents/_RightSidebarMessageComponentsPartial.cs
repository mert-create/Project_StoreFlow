using Microsoft.AspNetCore.Mvc;
using Project_StoreFlow.Context;

namespace Project_StoreFlow.ViewComponents.RightSidebarComponents
{
    public class _RightSidebarMessageComponentsPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarMessageComponentsPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values =_context.Messages.Where(x=>x.IsRead==false).ToList();
            return View(values);
        }
    }
}
