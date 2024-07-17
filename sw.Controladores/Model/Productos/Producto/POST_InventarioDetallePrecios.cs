using System;
using System.Collections.Generic;
using System.Text;  

namespace sw.Controladores.Model.Productos.Producto
{
    public class POST_InventarioDetallePrecios
    {        
        public int E_InventarioId { get; set; }
         public Decimal PrecioVenta { get; set; }
         public Decimal CantidadMayoreo { get; set; }
         public Decimal MargenUtilidad { get; set; } 
 
    }
}