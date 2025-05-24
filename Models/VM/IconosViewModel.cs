#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Ferovi.Models.VM
{
    public class IconosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es requerido")]
        [StringLength(50, ErrorMessage = "El código no puede exceder los 50 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La clase CSS del icono es requerida")]
        [StringLength(50, ErrorMessage = "La clase CSS no puede exceder los 50 caracteres")]
        [Display(Name = "Clase CSS")]
        public string Class { get; set; }

        [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}
