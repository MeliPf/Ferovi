using Microsoft.AspNetCore.Mvc;

namespace Ferovi.ViewComponents
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
