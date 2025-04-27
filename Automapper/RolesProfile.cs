using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;

namespace Ferovi.Automapper
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {            
            CreateMap<Roles, RolesViewModel>();

            CreateMap<RolesViewModel, Roles>();
        }        
    }
}
