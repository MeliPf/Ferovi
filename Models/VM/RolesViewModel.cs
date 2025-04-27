#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Ferovi.Models.VM
{
    public class RolesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código del rol es requerido")]
        [StringLength(50, ErrorMessage = "El código del rol no puede exceder los 50 caracteres")]
        public string RolCodigo { get; set; }

        [StringLength(250, ErrorMessage = "La descripción no puede exceder los 250 caracteres")]
        public string RolDescripcion { get; set; }
    }
}
