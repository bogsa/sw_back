using System;
using System.Collections.Generic;
using System.Text; 
using sw.Entidades.Configuracion.Almacen;

namespace sw.Entidades.Almacen.Inventario
{
    public class E_InventarioDetallePrecios
    {
         public int IdInventarioDetallePrecios { get; set; }
         public int E_InventarioId { get; set; }
         public E_Inventario E_Inventario { get; set; }
         public Decimal PrecioVenta { get; set; }
         public Decimal Cantidad { get; set; }
         public Decimal MargenUtilidad { get; set; } 
 


    } 
}