using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;

namespace Ferovi.Automapper
{
    public class MenuPrincipalProfile : Profile
    {
        public MenuPrincipalProfile()
        {
            // Mapeo de MenusPrincipales a MenusPrincipalesViewModel
            CreateMap<MenusPrincipales, MenusPrincipalesViewModel>()
                .ForMember(dest => dest.Icono, opt => opt.MapFrom(src =>
                    src.IdIconoNavigation != null ? src.IdIconoNavigation.Class : null));

            // Mapeo de MenusPrincipalesViewModel a MenusPrincipales
            CreateMap<MenusPrincipalesViewModel, MenusPrincipales>();
        }
    }
}
