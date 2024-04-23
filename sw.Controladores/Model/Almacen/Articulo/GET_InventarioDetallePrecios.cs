using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Almacen.Articulo
{
    public class GET_InventarioDetallePrecios
    {  
         public int IdInventarioDetallePrecios { get; set; } 
         public Decimal PrecioVenta { get; set; }
         public Decimal Cantidad { get; set; }
         public Decimal MargenUtilidad { get; set; } 
    }
}
