#nullable disable
using System;
using System.ComponentModel.DataAnnotations;

namespace Ferovi.Models.VM
{
    public class UsuariosHistorialAccesosViewModel
    {
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public DateTime FechaUltimoAcceso { get; set; }

        public string UsuarioNombre { get; set; }

        public string UsuarioPrimerApellido { get; set; }

        public string UsuarioSegundoApellido { get; set; }

        public string UsuarioAlias { get; set; }

        public string UsuarioEmail { get; set; }
    }
}
