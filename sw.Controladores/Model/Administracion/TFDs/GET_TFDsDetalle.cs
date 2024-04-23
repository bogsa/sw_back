using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.TFDs;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Controladores.Administracion.TFDs
{
    public class GET_TFDsDetalle
    {
        public int IdDetalleTFD { get; set; }
        public DateTime FechaCompra { get; set; }
        public Decimal Precio { get; set; }
        public int CantidadTFD { get; set; } 
    }
}