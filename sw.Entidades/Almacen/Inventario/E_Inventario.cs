using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Administracion.CentroTrabajo;
using sw.Entidades.Almacen.Articulo; 

namespace sw.Entidades.Almacen.Inventario
{
    public class E_Inventario
    {
        public int IdInventario { get; set; }

        public int E_CentroTrabajoId { get; set; }
        public E_CentroTrabajo  E_CentroTrabajo { get; set; }
        public int E_ArticuloId { get; set; }
        public E_Articulo E_Articulo { get; set; } 
        public Decimal  Existencias { get; set; }
        public ICollection<E_InventarioDetallePrecios> e_InventarioDetallePrecios { get; set; }

  
      

    }
}
