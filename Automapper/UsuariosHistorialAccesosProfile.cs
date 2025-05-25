using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;

namespace Ferovi.Mappings
{
    public class UsuariosHistorialAccesosProfile : Profile
    {
        public UsuariosHistorialAccesosProfile()
        {
            CreateMap<UsuariosHistorialAccesos, UsuariosHistorialAccesosViewModel>()
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.IdUsuarioNavigation.Nombre))
                .ForMember(dest => dest.UsuarioPrimerApellido, opt => opt.MapFrom(src => src.IdUsuarioNavigation.PrimerApellido))
                .ForMember(dest => dest.UsuarioSegundoApellido, opt => opt.MapFrom(src => src.IdUsuarioNavigation.SegundoApellido))
                .ForMember(dest => dest.UsuarioAlias, opt => opt.MapFrom(src => src.IdUsuarioNavigation.Alias))
                .ForMember(dest => dest.UsuarioEmail, opt => opt.MapFrom(src => src.IdUsuarioNavigation.Email));

            CreateMap<UsuariosHistorialAccesosViewModel, UsuariosHistorialAccesos>();
        }
    }
}
