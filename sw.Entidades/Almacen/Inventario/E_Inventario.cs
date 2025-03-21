using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using sw.Entidades.Administracion.CentroTrabajo;
using sw.Entidades.Productos.Producto; 

namespace sw.Entidades.Almacen.Inventario
{
    public class E_Inventario
    {
        public int IdInventario { get; set; }

        public int E_CentroTrabajoId { get; set; }
        public E_CentroTrabajo  E_CentroTrabajo { get; set; }
        public int E_ProductoId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public E_Producto E_Producto { get; set; } 
        public Decimal  Existencias { get; set; }
        public Decimal PrecioBase { get; set; }
        public string Localizacion { get; set; }

   
  
      

    }
}
