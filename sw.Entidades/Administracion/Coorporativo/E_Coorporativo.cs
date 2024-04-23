using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using sw.Entidades.Administracion.Empresa;

namespace sw.Entidades.Administracion.Coorporativo
{
    public class E_Coorporativo
    {
        [Key]
        public int IdCoorporativo { get; set; }
        [Required]
        [StringLength(80)]
        public string Nombre { get; set; } 
        public string Guid { get; set; }
        public Boolean Status { get; set; }
        public ICollection<E_Empresa> e_Empresas {get; set;}

    }
}
