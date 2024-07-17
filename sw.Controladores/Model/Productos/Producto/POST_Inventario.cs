using System;
using System.Collections.Generic;
using System.Text;  

namespace sw.Controladores.Model.Productos.Producto
{
    public class POST_Inventario
    {  
        public int E_CentroTrabajoId { get; set; } 
        public int E_ProductoId { get; set; } 
        public Decimal  Existencias { get; set; } 
      
    }
}
