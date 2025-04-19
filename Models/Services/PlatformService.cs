#nullable disable
using Ferovi.Models.Repositories.Interfaces;
using Ferovi.Models.VM;

namespace Ferovi.Models.Services
{
    public class PlatformService()
    {
        private readonly IMenuPrincipalRepository _menuPrincipalRepository;

        public List<MenuPrincipalViewModel> EstructurarMenu()
        {
            Task<IEnumerable<EF.MenuPrincipal>> menuItems = _menuPrincipalRepository.GetAllAsync();

            // Obtener todos los elementos de nivel 1 (menú principal)
            var menuPrincipal = menuItems
                .Where(m => m.Nivel == 1)
                .ToList();

            // Para cada elemento del menú principal, buscar sus submenús
            foreach (var menu in menuPrincipal)
            {
                // Obtener submenús directos (nivel 2)
                var submenus = menuItems
                    .Where(m => m.IdMenuPadre == menu.Id)
                    .ToList();

                // Para cada submenu, buscar sus submenús (nivel 3)
                foreach (var submenu in submenus)
                {
                    submenu.Submenu = menuItems
                        .Where(m => m.IdMenuPadre == submenu.Id)
                        .ToList();
                }

                menu.Submenu = submenus;
            }

            return menuPrincipal;
        }
    }
}
