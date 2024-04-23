using System.Collections.Generic;

namespace sw.Controladores.Model.Administracion.Usuarios
{
    public class POST_UsuarioCentroTrabajo
    {
        public string IdUsuario { get; set; }
        public List<POST_CentroTrabajoes> CentroTrabajoes { get; set; }

    }
}
