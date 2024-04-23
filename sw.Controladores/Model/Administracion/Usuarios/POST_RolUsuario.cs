using sw.Controladores.Model.Administracion.Modulos;
using sw.Controladores.Model.Administracion.Perfiles;
using System;
using System.Collections.Generic;

namespace sw.Controladores.Model.Administracion.Usuarios
{
    public class POST_RolUsuario
    {
        public string IdUsuario { get; set; }
        public List<POST_RolesClaims> Roles { get; set; }

    }
}
