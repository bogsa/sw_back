using System;
using System.Collections.Generic;
using System.Text; 


namespace sw.Controladores.Model.Configuracion.CatalogosAlmacen.Proveedor
{
    public class PUT_Proveedor
    {
        public int IdProveedor { get; set; }
        public int E_CorporativoId { get; set; } 
        public string Nombre { get; set; }
        public string SitioWeb { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
 
    }
}