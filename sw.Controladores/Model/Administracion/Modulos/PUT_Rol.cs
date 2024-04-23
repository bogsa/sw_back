using System;

namespace sw.Controladores.Model.Administracion.Modulos
{ 
    public class PUT_Rol
    {
        public Guid IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Icono { get; set; }
        public string Color { get; set; }
        public string Tooltip { get; set; }
        public int Prioridad { get; set; }
        public bool Activo { get; set; }
    }
}
