using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Almacen.Articulo
{
    public class PUT_InventarioCP
    { 
        /*---   COSTOS Y PRECIOS   ---------------------------------------------------------*/
       public int IdArticulo { get; set; }
        public int E_UnidadMedidaCId  { get; set; }
        public int E_UnidadMedidaVId  { get; set; }
        public Decimal PrecioCompra { get; set; }
        public Decimal Factor { get; set; } 
    }

  
}
