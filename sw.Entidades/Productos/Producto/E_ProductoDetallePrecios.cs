using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Entidades.Productos.Producto
{
    public class E_ProductoDetallePrecios
    {
        public int IdProductoDetallePrecios { get; set; }
        public int E_ProductoId { get; set; } 
        public E_Producto E_Producto { get; set; }
        public Decimal PrecioVenta { get; set; }
        public Decimal CantidadMenor { get; set; }
        public Decimal CantidadMayor { get; set; }
        public Decimal MargenUtilidad { get; set; }



    }
}