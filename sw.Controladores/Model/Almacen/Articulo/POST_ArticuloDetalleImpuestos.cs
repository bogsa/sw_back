using System;
using System.Collections.Generic;
using System.Text; 
using sw.Entidades.Configuracion.Almacen;

namespace sw.Controladores.Model.Almacen.Articulo
{
    public class POST_ArticuloDetalleImpuestos
    { 
      
       public int E_ArticuloId { get; set; }
         public string TipoImpuesto { get; set; }
         public string Impuesto { get; set; }
         public string TipoFactor { get; set; }
         public Decimal Valor { get; set; }


    }
}
