using AutoMapper;
using Ferovi.Models.EF;
using Ferovi.Models.VM;

namespace Ferovi.Automapper
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {            
            CreateMap<Usuarios, UsuariosViewModel>();    
            
            CreateMap<UsuariosViewModel, Usuarios>();    
        }
    }
}
