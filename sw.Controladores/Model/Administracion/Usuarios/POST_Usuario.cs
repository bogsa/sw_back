using System;

namespace sw.Controladores.Model.Administracion.Usuarios
{
    public class POST_Usuario
    {
        public string Usuario { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }
        public string Password { get; set; }
        public string Perfil { get; set; }
        public int e_CentroTrabajoId { get; set; } 
        
        public string NombreCompleto { get; set; } 

    }
}
