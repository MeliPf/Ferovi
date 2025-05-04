using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.Repositories.Interfaces;
using Ferovi.Models.Services.Interfaces;
using Ferovi.Models.VM;

namespace Ferovi.Models.Services
{
    public class UsuariosService(IUsuariosRepository usuariosRepository, IRolesRepository rolesRepository, IUsuariosRolesRepository usuariosRolesRepository,
                                 IMapper mapper) : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository = usuariosRepository;
        private readonly IRolesRepository _rolesRepository = rolesRepository;
        private readonly IUsuariosRolesRepository _usuariosRolesRepository = usuariosRolesRepository;
        private readonly IMapper _mapper = mapper;

        #region USUARIOS
        public async Task<List<UsuariosViewModel>> GetAllUsersAsync()
        {
            IEnumerable<Usuarios> listUsers = await _usuariosRepository.GetAllAsync();
            return _mapper.Map<List<UsuariosViewModel>>(listUsers);
        }

        public async Task<List<UsuariosViewModel>> GetAllByDatatablesFiltersUsuariosAsync(int start, int length, string searchValue, string filterUserName, string filterFirstLastName, string filterSecondLastName, string filterAlias, string filterEmail, string sortColumn, string sortDirection)
        {
            IEnumerable<Usuarios> listUsers = await _usuariosRepository.GetAllByDatatablesFiltersAsync(start, length, searchValue, filterUserName, filterFirstLastName, filterSecondLastName, filterAlias, filterEmail, sortColumn, sortDirection);
            return _mapper.Map<List<UsuariosViewModel>>(listUsers);
        }

        public async Task<UsuariosViewModel> GetUsersByIdAsync(int id)
        {
            Usuarios users = await _usuariosRepository.GetByIdAsync(id);
            return _mapper.Map<UsuariosViewModel>(users);
        }

        public async Task CreateUsersAsync(UsuariosViewModel usersViewModel)
        {
            Usuarios users = _mapper.Map<Usuarios>(usersViewModel);
            await _usuariosRepository.CreateAsync(users);
        }

        public async Task UpdateUsersAsync(UsuariosViewModel usersViewModel)
        {
            Usuarios users = _mapper.Map<Usuarios>(usersViewModel);
            await _usuariosRepository.UpdateAsync(users);
        }

        public async Task DeleteUsersAsync(int idUsuario)
        {
            await _usuariosRepository.DeleteAsync(idUsuario);
        }
        #endregion

        #region ROLES
        public async Task<List<RolesViewModel>> GetAllRolesAsync()
        {
            IEnumerable<Roles> listRoles = await _rolesRepository.GetAllAsync();
            return _mapper.Map<List<RolesViewModel>>(listRoles);
        }

        public async Task<List<RolesViewModel>> GetAllByDatatablesFilterRolessAsync(int start, int length, string searchValue, string filterCode, string filterDescription, string sortColumn, string sortDirection)
        {
            IEnumerable<Roles> listRoles = await _rolesRepository.GetAllByDatatablesFiltersAsync(start, length, searchValue, filterCode, filterDescription, sortColumn, sortDirection);
            return _mapper.Map<List<RolesViewModel>>(listRoles);
        }

        public async Task<RolesViewModel> GetRolesByIdAsync(int id)
        {
            Roles roles = await _rolesRepository.GetByIdAsync(id);
            return _mapper.Map<RolesViewModel>(roles);
        }
        public async Task CreateRolAsync(RolesViewModel rolesViewModel)
        {
            Roles roles = _mapper.Map<Roles>(rolesViewModel);
            await _rolesRepository.CreateAsync(roles);
        }

        public async Task DeleteRolAsync(int id)
        {
            await _rolesRepository.DeleteAsync(id);
        }
        #endregion

        #region USUARIOS_ROLES
        public async Task CreateUsersRolesAsync(int idUsers, int idRoles)
        {
            Usuarios_Roles usersRoles = new()
            {
                IdUsuario = idUsers,
                IdRol = idRoles
            };

            await _usuariosRolesRepository.CreateAsync(usersRoles);
        }

        public async Task DeleteUsersRolesAsync(int id)
        {
            await _usuariosRolesRepository.DeleteAsync(id);
        }
        #endregion
    }
}
