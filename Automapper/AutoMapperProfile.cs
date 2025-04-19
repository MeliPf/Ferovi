using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;

namespace Ferovi.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeo de MenuPrincipal a MenuPrincipalViewModel
            CreateMap<MenuPrincipal, MenuPrincipalViewModel>()
                .ForMember(dest => dest.Icono, opt => opt.MapFrom(src =>
                    src.IdIconoNavigation != null ? src.IdIconoNavigation.Class : null));

            // Mapeo de MenuPrincipalViewModel a MenuPrincipal
            CreateMap<MenuPrincipalViewModel, MenuPrincipal>();
        }
    }
}
