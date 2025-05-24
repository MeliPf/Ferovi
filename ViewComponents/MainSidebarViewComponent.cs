using Ferovi.Models.VM;
using Ferovi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ferovi.ViewComponents
{
    public class MainSidebarViewComponent(IPlataformaService servicioPlataforma) : ViewComponent
    {
        private readonly IPlataformaService _servicioPlataforma = servicioPlataforma;

        public IViewComponentResult Invoke()
        {
            List<MenusPrincipalesViewModel> menuPrincipal = _servicioPlataforma.ObtenerMenuPrincipal();

            return View(menuPrincipal);
        }
    }
}
