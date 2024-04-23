using System;

namespace sw.Controladores.Model.Administracion.Usuarios
{
    public class GET_Usuarios
    {
        public string idUsuario { get; set; }
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset?  LockoutEnd { get; set; }
        public Boolean LockoutEnable { get; set; }
        public int AccesFailedCount { get; set; }
        public string Perfil { get; set; }
        public string NombreCompleto { get; set; }
        public Boolean Aprobado { get; set; }
        
        public int e_CentroTrabajoId { get; set; }
        public string CentroTrabajo { get; set; }

        public int e_EmpresaId { get; set; }
        public int e_CorporativoId { get; set; }
    }
}
