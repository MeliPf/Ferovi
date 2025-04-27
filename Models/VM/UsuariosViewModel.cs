#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Ferovi.Models.VM
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [StringLength(50, ErrorMessage = "El primer apellido no puede exceder los 50 caracteres")]
        public string PrimerApellido { get; set; }

        [StringLength(50, ErrorMessage = "El segundo apellido no puede exceder los 50 caracteres")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El alias es requerido")]
        [StringLength(50, ErrorMessage = "El alias no puede exceder los 50 caracteres")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [StringLength(50, ErrorMessage = "El email no puede exceder los 50 caracteres")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
