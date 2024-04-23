using System.Collections.Generic;

namespace sw.Controladores.Model.Administracion.Perfiles
{
    public class GET_ModulosPerfil
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }

        public string RolId { get; set; }

        public List<GET_PermisosPerfil> children { get; set; }
    }
}
