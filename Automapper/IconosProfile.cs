using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;

namespace Ferovi.Automapper
{
    public class IconosProfile : Profile
    {
        public IconosProfile()
        {            
            CreateMap<Iconos, IconosViewModel>();

            CreateMap<IconosViewModel, Iconos>();
        }        
    }
}
