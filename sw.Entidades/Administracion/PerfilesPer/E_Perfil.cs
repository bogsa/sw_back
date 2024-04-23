using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sw.Entidades.Administracion.PerfilesPer
{
   public class E_Perfil
    {
        [Key]
        public int IdPerfil { get; set; }
        [StringLength(200)]
        public string NombrePerfil { get; set; }
     
    }
}
