
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using sw.Entidades.Identity;

namespace sw.Entidades.Administracion.PerfilesPer
{
    public class E_Modulo
    {
        [Key]
        public int IdModulo { get; set; }
        [ForeignKey("RolId")]
        public string RolId { get; set; }
        public ApplicationRol Rol { get; set; }
        [ForeignKey("E_PerfilId")]
        public int E_PerfilId { get; set; }
        public E_Perfil E_Perfil { get; set; }

    }
}
