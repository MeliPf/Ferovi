using Ferovi.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ferovi.ViewComponents
{
    public class MainSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            PlatformService platformService = new();

            var a = platformService.EstructurarMenu();

            return View(a);
        }
    }
}
