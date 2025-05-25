using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;
using Ferovi.Repositories.Interfaces;
using Ferovi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Services
{
    public class UsuariosService(IBaseRepository<Usuarios> usuariosRepository, IBaseRepository<Roles> rolesRepository, IBaseRepository<UsuariosHistorialAccesos> usuariosHistorialAccesosRepository, IMapper mapper) : IUsuariosService
    {
        private readonly IBaseRepository<Usuarios> _usuariosRepository = usuariosRepository;
        private readonly IBaseRepository<Roles> _rolesRepository = rolesRepository;
        private readonly IBaseRepository<UsuariosHistorialAccesos> _usuariosHistorialAccesosRepository = usuariosHistorialAccesosRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<UsuariosViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, string filterEmail, string sortColumn, string sortDirection)
        {
            IQueryable<Usuarios> query = _usuariosRepository.Consulta();

            if (!string.IsNullOrEmpty(filterUserName))
            {
                query = query.Where(ur => ur.Nombre.Contains(filterUserName));
            }

            if (!string.IsNullOrEmpty(filterFirstLastName))
            {
                query = query.Where(ur => ur.PrimerApellido.Contains(filterFirstLastName));
            }

            if (!string.IsNullOrEmpty(filterSecondLastName))
            {
                query = query.Where(ur => ur.SegundoApellido.Contains(filterSecondLastName));
            }

            if (!string.IsNullOrEmpty(filterAlias))
            {
                query = query.Where(ur => ur.Alias.Contains(filterAlias));
            }

            if (!string.IsNullOrEmpty(filterEmail))
            {
                query = query.Where(ur => ur.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(ur =>
                    ur.Nombre.Contains(searchValue) ||
                    ur.PrimerApellido.Contains(searchValue) ||
                    ur.SegundoApellido.Contains(searchValue) ||
                    ur.Email.Contains(searchValue) ||
                    ur.Alias.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Nombre" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Nombre)
                        : query.OrderByDescending(ur => ur.Nombre),
                    "PrimerApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.PrimerApellido)
                        : query.OrderByDescending(ur => ur.PrimerApellido),
                    "SegundoApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.SegundoApellido)
                        : query.OrderByDescending(ur => ur.SegundoApellido),
                    "Email" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Email)
                        : query.OrderByDescending(ur => ur.Email),
                    "Alias" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Alias)
                        : query.OrderByDescending(ur => ur.Alias),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            List<Usuarios> listaUsuarios = await query.ToListAsync();

            return _mapper.Map<List<UsuariosViewModel>>(listaUsuarios);
        }

        public async Task<IEnumerable<RolesViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterCode, string filterDescription, string sortColumn, string sortDirection)
        {
            IQueryable<Roles> query = _rolesRepository.Consulta();

            if (!string.IsNullOrEmpty(filterCode))
            {
                query = query.Where(ur => ur.Codigo.Contains(filterCode));
            }

            if (!string.IsNullOrEmpty(filterDescription))
            {
                query = query.Where(ur => ur.Descripcion.Contains(filterDescription));
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(ur =>
                    ur.Codigo.Contains(searchValue) ||
                    ur.Descripcion.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Codigo" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Codigo)
                        : query.OrderByDescending(ur => ur.Codigo),
                    "Descripcion" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.Descripcion)
                        : query.OrderByDescending(ur => ur.Descripcion),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            List<Roles> listaRoles = await query.ToListAsync();

            return _mapper.Map<List<RolesViewModel>>(listaRoles);
        }

        public async Task<IEnumerable<UsuariosHistorialAccesosViewModel>> GetAllByDatatablesFiltersAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, DateTime? filterDate, string sortColumn, string sortDirection)
        {
            IQueryable<UsuariosHistorialAccesos> query = _usuariosHistorialAccesosRepository.Consulta();

            if (!string.IsNullOrEmpty(filterUserName))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.Nombre.Contains(filterUserName));
            }

            if (!string.IsNullOrEmpty(filterFirstLastName))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.PrimerApellido.Contains(filterFirstLastName));
            }

            if (!string.IsNullOrEmpty(filterSecondLastName))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.SegundoApellido.Contains(filterSecondLastName));
            }

            if (!string.IsNullOrEmpty(filterAlias))
            {
                query = query.Where(ur => ur.IdUsuarioNavigation.Alias.Contains(filterAlias));
            }

            if (filterDate != null)
            {
                query = query.Where(ur => ur.FechaUltimoAcceso == filterDate); // TODO: verificar que no se compare los segundos.
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(ur =>
                    ur.IdUsuarioNavigation.Nombre.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.PrimerApellido.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.SegundoApellido.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.Email.Contains(searchValue) ||
                    ur.IdUsuarioNavigation.Alias.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
            {
                query = sortColumn switch
                {
                    "Nombre" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.Nombre)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.Nombre),
                    "PrimerApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.PrimerApellido)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.PrimerApellido),
                    "SegundoApellido" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.SegundoApellido)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.SegundoApellido),
                    "Email" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.Email)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.Email),
                    "Alias" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.IdUsuarioNavigation.Alias)
                        : query.OrderByDescending(ur => ur.IdUsuarioNavigation.Alias),
                    "FechaUltimoAcceso" => sortDirection == "asc"
                        ? query.OrderBy(ur => ur.FechaUltimoAcceso)
                        : query.OrderByDescending(ur => ur.FechaUltimoAcceso),
                    _ => query
                };
            }

            query = query.Skip(start).Take(length);

            List<UsuariosHistorialAccesos> listaUsuariosHistorialAccesos = await query.ToListAsync();

            return _mapper.Map<List<UsuariosHistorialAccesosViewModel>>(listaUsuariosHistorialAccesos);
        }
    }
}
