using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sw.Entidades.Administracion.TFDs
{
    public class E_TFDsDetalle
    {
        [Key]
        public int IdDetalleTFD { get; set; }
        public DateTime FechaCompra { get; set; }
        public Decimal  Precio{ get; set; }
        public int CantidadTFD { get; set; }
        [ForeignKey("E_TFDsGlobalId")]
        public int E_TFDsGlobalId { get; set; }
        public E_TFDsGlobal E_TFDsGlobal { get; set; }

    }
}
