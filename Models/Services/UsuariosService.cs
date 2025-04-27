using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.Repositories;
using Ferovi.Models.Repositories.Interfaces;
using Ferovi.Models.Services.Interfaces;
using Ferovi.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace Ferovi.Models.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IUsuariosRolesRepository _usuariosRolesRepository;
        private readonly IMapper _mapper;

        public UsuariosService(IUsuariosRepository usuariosRepository, IRolesRepository rolesRepository, IUsuariosRolesRepository = usuariosRolesRepository IMapper mapper)
        {
            _usuariosRepository = usuariosRepository;
            _rolesRepository = rolesRepository;
            _usuariosRolesRepository = usuariosRolesRepository;
            _mapper = mapper;
        }

        #region USUARIOS
        public async Task<List<UsuariosViewModel>> GetAllUsuariosAsync()
        {
            var entities = await _usuariosRepository.GetAllAsync();
            return _mapper.Map<List<UsuariosViewModel>>(entities);
        }

        public async Task<UsuariosViewModel> GetUsuariosByIdAsync(int id)
        {
            var entity = await _usuariosRepository.GetByIdAsync(id);
            return _mapper.Map<UsuariosViewModel>(entity);
        }

        public async Task CreateUsuarioAsync(UsuariosViewModel modelo)
        {
            var entity = _mapper.Map<Usuarios_Roles>(modelo);
            await _usuariosRepository.CreateAsync(entity);
        }

        public async Task UpdateUsuarioAsync(UsuariosViewModel modelo)
        {
            var entity = _mapper.Map<Usuarios_Roles>(modelo);
            await _usuariosRepository.UpdateAsync(entity);
        }

        public async Task DeleteUsuarioAsync(int idUsuario)
        {
            var entities = await _usuariosRepository.GetAllAsync();
            var usuarioRoles = entities.Where(x => x.IdUsuario == idUsuario);
            foreach (var ur in usuarioRoles)
            {
                await _usuariosRepository.DeleteAsync(ur.Id);
            }
        }

        public async Task<List<UsuariosViewModel>> GetAllByDatatablesFiltersUsuariosAsync(int start, int length, string searchValue, string filterUserName, string filterRole, string sortColumn, string sortDirection)
        {
            var entities = await _usuariosRepository.GetAllByDatatablesFiltersAsync(start, length, searchValue, filterUserName, filterRole, sortColumn, sortDirection);
            return _mapper.Map<List<UsuariosViewModel>>(entities);
        }
        #endregion

        #region ROLES
        public async Task<List<RolesViewModel>> GetAllRolesAsync()
        {
            var entities = await _rolesRepository.GetAllAsync();
            return _mapper.Map<List<RolesViewModel>>(entities);
        }

        public async Task<RolesViewModel> GetRolesByIdAsync(int id)
        {
            var entity = await _rolesRepository.GetByIdAsync(id);
            return _mapper.Map<RolesViewModel>(entity);
        }

        public async Task CreateRolAsync(RolesViewModel modelo)
        {
            var entity = _mapper.Map<RolesViewModel>(modelo);
            await _rolesRepository.CreateAsync(entity);
        }

        public async Task DeleteRolAsync(int idRol)
        {
            // Eliminar todas las relaciones del rol
            var entities = await _rolesRepository.GetAllAsync();
            var rolUsuarios = entities.Where(x => x.IdRol == idRol);
            foreach (var ru in rolUsuarios)
            {
                await _rolesRepository.DeleteAsync(ru.Id);
            }
        }

        public async Task<List<RolesViewModel>> GetAllByDatatablesFilterRolessAsync(int start, int length, string searchValue, string filterUserName, string filterRole, string sortColumn, string sortDirection)
        {
            var entities = await _rolesRepository.GetAllByDatatablesFiltersAsync(start, length, searchValue, filterUserName, filterRole, sortColumn, sortDirection);
            return _mapper.Map<List<RolesViewModel>>(entities);
        }
        #endregion

        #region USUARIOS_ROLES
        public async Task AssignRolAUsuarioAsync(int idUsuario, int idRol)
        {
            var modelo = new UsuariosViewModel
            {
                IdUsuario = idUsuario,
                IdRol = idRol
            };
            await CrearUsuarioAsync(modelo);
        }

        public async Task DeleteRolDeUsuarioAsync(int idUsuario, int idRol)
        {
            var entities = await _usuariosRolesRepository.GetAllAsync();
            var usuarioRol = entities.FirstOrDefault(x => x.IdUsuario == idUsuario && x.IdRol == idRol);
            if (usuarioRol != null)
            {
                await _usuariosRolesRepository.DeleteAsync(usuarioRol.Id);
            }
        }
        #endregion
    }
}
