using Ferovi.Models.Services.Interfaces;
using Ferovi.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Ferovi.ViewComponents
{
    public class MainSidebarViewComponent(IPlataformaService servicioPlataforma) : ViewComponent
    {
        private readonly IPlataformaService _servicioPlataforma = servicioPlataforma;

        public IViewComponentResult Invoke()
        {
            List<MenuPrincipalViewModel> menuPrincipal = _servicioPlataforma.ObtenerMenuPrincipal();

            return View(menuPrincipal);
        }
    }
}
