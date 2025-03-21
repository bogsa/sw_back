using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using sw.Entidades.Administracion.Coorporativo;
using sw.Entidades.Productos;

namespace sw.Entidades.Productos.Departamento
{
    public class E_Departamento
    {
        
        [Key]
        public int IdDepartamento { get; set; }
        [Required]
        public string Nombre { get; set; } 
        public int E_CorporativoId { get; set; }
        public E_Coorporativo E_Corporativo { get; set; }
        public Boolean Status { get; set; }

      
    }
}




