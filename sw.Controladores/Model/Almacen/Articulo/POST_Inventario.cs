using System;
using System.Collections.Generic;
using System.Text; 
using sw.Entidades.Configuracion.Almacen;

namespace sw.Controladores.Model.Almacen.Articulo
{
    public class POST_Inventario
    {  
        public int E_CentroTrabajoId { get; set; } 
        public int E_ArticuloId { get; set; } 
        public Decimal  Existencias { get; set; } 
      
    }
}
