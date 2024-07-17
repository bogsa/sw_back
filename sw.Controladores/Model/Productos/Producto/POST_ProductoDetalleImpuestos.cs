using System;
using System.Collections.Generic;
using System.Text;  

namespace sw.Controladores.Model.Productos.Producto
{
    public class POST_ProductoDetalleImpuestos
    { 
      
       public int E_ProductoId { get; set; }
         public string TipoImpuesto { get; set; }
         public string Impuesto { get; set; }
         public string TipoFactor { get; set; }
         public Decimal Valor { get; set; }


    }
}
