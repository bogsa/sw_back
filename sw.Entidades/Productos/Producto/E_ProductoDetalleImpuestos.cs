using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text; 
using sw.Entidades.Configuracion.Almacen;
using sw.Entidades.Productos.Producto;

namespace sw.Entidades.Productos.Producto
{
    public class E_ProductoDetalleImpuestos
    {
        [Key]
         public int IdProductoDetalleImpuestos { get; set; }
         public int E_ProductoId { get; set; }
         public E_Producto E_Producto { get; set; }
         public string TipoImpuesto { get; set; }
         public string Impuesto { get; set; }
         public string TipoFactor { get; set; }
         public Decimal Valor { get; set; }


    }
}
