using System.Collections.Generic;

namespace sw.Controladores.Model.Administracion.Usuarios
{
    public class POST_UsuarioEmpresas
    {
        public string idUsuario { get; set; }
        public List<POST_Empresas> Empresas { get; set; }

    }
}
