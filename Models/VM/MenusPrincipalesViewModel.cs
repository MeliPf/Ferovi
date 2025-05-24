#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Ferovi.Models.VM
{
    public class MenusPrincipalesViewModel
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string Nombre { get; set; }

        [StringLength(50, ErrorMessage = "El enlace no puede exceder los 50 caracteres")]
        public string Enlace { get; set; }

        public string Icono { get; set; }

        public int Nivel { get; set; }

        public int? IdMenuPadre { get; set; }

        public List<MenusPrincipalesViewModel> Submenu { get; set; } = [];
    }
}