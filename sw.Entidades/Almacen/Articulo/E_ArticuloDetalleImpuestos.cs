using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text; 
using sw.Entidades.Configuracion.Almacen;

namespace sw.Entidades.Almacen.Articulo
{
    public class E_ArticuloDetalleImpuestos
    {
        [Key]
         public int IdArticuloDetalleImpuestos { get; set; }
         public int E_ArticuloId { get; set; }
         public E_Articulo E_Articulo { get; set; }
         public string TipoImpuesto { get; set; }
         public string Impuesto { get; set; }
         public string TipoFactor { get; set; }
         public Decimal Valor { get; set; }


    }
}
