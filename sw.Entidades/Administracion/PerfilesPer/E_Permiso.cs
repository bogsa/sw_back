
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using sw.Entidades.Identity;

namespace sw.Entidades.Administracion.PerfilesPer
{
    public class E_Permiso
    {
        [Key]
        public int IdPermiso { get; set; }
        [ForeignKey("E_ModuloId")]
        public int E_ModuloId { get; set; }
        public E_Modulo E_Modulo { get; set; }
        [ForeignKey("ClaimId")]
        public int ClaimId { get; set; }
        public ApplicationRoleClaim Claim { get; set; }

    }
}
