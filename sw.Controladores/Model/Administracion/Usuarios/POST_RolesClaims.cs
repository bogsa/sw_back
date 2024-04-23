using System;
using System.Collections.Generic;

namespace sw.Controladores.Model.Administracion.Usuarios
{
    public class POST_RolesClaims
    {
        public string RolId { get; set; }
        public List<POST_Claims> children { get; set; }
    }
}
