using Microsoft.AspNetCore.Mvc;

namespace Ferovi.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
