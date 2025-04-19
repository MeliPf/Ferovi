using Microsoft.AspNetCore.Mvc;

namespace Ferovi.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
