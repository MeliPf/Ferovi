#nullable disable

namespace Ferovi.Models.VM
{
    public class MenuPrincipalViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Enlace { get; set; }
        public string Icono { get; set; }
        public int Nivel { get; set; }
        public int IdMenuPadre { get; set; }
        public List<MenuPrincipalViewModel> Submenu { get; set; } = [];
    }
}