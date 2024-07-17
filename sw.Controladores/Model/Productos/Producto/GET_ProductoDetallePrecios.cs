using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Productos.Producto
{
    public class GET_ProductoDetallePrecios
    {  
         public int IdProductoDetallePrecios { get; set; } 
         public Decimal PrecioVenta { get; set; }
         public Decimal CantidadMayor { get; set; }
         public Decimal CantidadMenor { get; set; }
         public Decimal MargenUtilidad { get; set; } 
    }
}
