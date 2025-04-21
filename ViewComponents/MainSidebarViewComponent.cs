using Ferovi.Models.Services.Interfaces;
using Ferovi.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Ferovi.ViewComponents
{
    public class MainSidebarViewComponent(IMenuPrincipalService servicioMenuPrincipal) : ViewComponent
    {
        private readonly IMenuPrincipalService _servicioMenuPrincipal = servicioMenuPrincipal;

        public IViewComponentResult Invoke()
        {
            List<MenuPrincipalViewModel> menuPrincipal = _servicioMenuPrincipal.ObtenerMenuPrincipal();

            return View(menuPrincipal);
        }
    }
}
