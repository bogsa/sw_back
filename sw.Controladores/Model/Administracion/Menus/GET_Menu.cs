using System;

namespace sw.Controladores.Model.Administracion.Menus
{
    public class GET_Menu
    {
        public Guid IdMenu { get; set; }
        public Guid IdRol { get; set; }
        public string Titulo { get; set; }
        public string Icono { get; set; }
    }
}
