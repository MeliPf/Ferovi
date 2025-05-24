using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;
using Ferovi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Services
{
    public class PlataformaService(IMapper mapper, IBaseRepository<MenusPrincipales> menusPrincipalesRepository, IBaseRepository<Iconos> IconosRepository)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBaseRepository<MenusPrincipales> _menuPrincipalRepository = menusPrincipalesRepository;
        private readonly IBaseRepository<Iconos> _iconosRepository = IconosRepository;

        public async Task<IEnumerable<MenusPrincipalesViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterName, string filterLink, int filterLevel, string sortColumn, string sortDirection)
        {
            IQueryable<MenusPrincipales> query = _menuPrincipalRepository.Consulta();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(m =>
                    m.Nombre.Contains(searchValue) ||
                    m.Enlace.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                query = query.Where(m => m.Nombre.Contains(filterName));
            }

            if (!string.IsNullOrEmpty(filterLink))
            {
                query = query.Where(m => m.Enlace.Contains(filterLink));
            }

            if (filterLevel > 0)
            {
                query = query.Where(m => m.Nivel.Equals(filterLevel));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Nombre" => sortDirection == "asc"
                        ? query.OrderBy(m => m.Nombre)
                        : query.OrderByDescending(m => m.Nombre),
                    "Enlace" => sortDirection == "asc"
                        ? query.OrderBy(m => m.Enlace)
                        : query.OrderByDescending(m => m.Enlace),
                    "Nivel" => sortDirection == "asc"
                        ? query.OrderBy(m => m.Nivel)
                        : query.OrderByDescending(m => m.Nivel),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            List<MenusPrincipales> listaMenusPrincipales = await query.ToListAsync();

            return _mapper.Map<List<MenusPrincipalesViewModel>>(listaMenusPrincipales);
        }

        public async Task<IEnumerable<IconosViewModel>> GetAllAsync()
        {
            List<Iconos> listaIconos = await _iconosRepository.Consulta().ToListAsync();
            return _mapper.Map<List<IconosViewModel>>(listaIconos);
        }

        public async Task<IEnumerable<MenusPrincipalesViewModel>> ObtenerMenuPrincipal()
        {
            List<MenusPrincipales> listaMenusPrincipales = await _menuPrincipalRepository.Consulta()
                .Include(m => m.IdIconoNavigation)
                .ToListAsync();

            List<MenusPrincipalesViewModel> todosLosMenus = _mapper.Map<List<MenusPrincipalesViewModel>>(listaMenusPrincipales);

            List<MenusPrincipalesViewModel> menuPrincipal = [.. todosLosMenus
                .Where(m => m.Nivel == 1)
                .Select(menu =>
                {
                    menu.Submenu = [.. todosLosMenus
                        .Where(m => m.IdMenuPadre == menu.Id)
                        .Select(submenu =>
                        {
                            submenu.Submenu = [.. todosLosMenus.Where(m => m.IdMenuPadre == submenu.Id)];
                            return submenu;
                        })];
                    return menu;
                })];

            return menuPrincipal;
        }
    }
}
