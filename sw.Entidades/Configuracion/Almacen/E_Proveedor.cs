using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using sw.Entidades.Administracion.Coorporativo;

namespace sw.Entidades.Configuracion.Almacen
{
    public class E_Proveedor
    {
        public int IdProveedor { get; set; }
        public int E_CorporativoId { get; set; }
        public E_Coorporativo E_Corporativo { get; set; }
        public string Nombre { get; set; }
        public string SitioWeb { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

 
    }
}
