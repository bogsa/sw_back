using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Administracion.Coorporativo;

namespace sw.Entidades.Configuracion.Almacen
{
    public class E_Marca
    {
        public int IdMarca { get; set; }
        public int E_CorporativoId { get; set; }
        public E_Coorporativo E_Corporativo { get; set; }
        public string Descripcion { get; set; }
 
    }
}
