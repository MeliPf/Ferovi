#nullable disable
using AutoMapper;
using Ferovi.Models.Repositories.Interfaces;
using Ferovi.Models.VM;

namespace Ferovi.Models.Services
{
    public class PlataformaService(IMenusPrincipalesRepository menusPrincipales, IMapper mapper) : IPlataformaService
    {
        private readonly IMenusPrincipalesRepository _menuPrincipalRepository = menusPrincipales;
        private readonly IMapper _mapper = mapper;

        public List<MenuPrincipalViewModel> ObtenerMenuPrincipal()
        {
            List<MenuPrincipalViewModel> puntosMenu = _mapper
                .Map<List<MenuPrincipalViewModel>>(_menuPrincipalRepository.GetAllAsync().Result);

            IEnumerable<MenuPrincipalViewModel> menuPrincipal = [.. puntosMenu.Where(m => m.Nivel == 1)];

            // Para cada elemento del menú principal, buscar sus submenús
            foreach (MenuPrincipalViewModel puntoMenu in menuPrincipal)
            {
                // Obtener submenús directos (nivel 2)
                IEnumerable<MenuPrincipalViewModel> submenusPrimarios = [.. puntosMenu.Where(m => m.IdMenuPadre == puntoMenu.Id)];

                // Para cada submenu, buscar sus submenús (nivel 3)
                foreach (MenuPrincipalViewModel submenu in submenusPrimarios)
                {
                    submenu.Submenu = [.. puntosMenu.Where(m => m.IdMenuPadre == submenu.Id)];
                }

                puntoMenu.Submenu = [.. submenusPrimarios];
            }

            return [.. menuPrincipal];
        }
    }
}
