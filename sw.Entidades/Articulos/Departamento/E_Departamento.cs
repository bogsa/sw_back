using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Administracion.Coorporativo;
using sw.Entidades.Articulos.Articulo;

namespace sw.Entidades.Articulos.Departamento
{
    public class E_Departamento
    {

        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } 
        public int E_CorporativoId { get; set; }
        public E_Coorporativo E_Corporativo { get; set; }
        public Boolean Status { get; set; }

      
    }
}




