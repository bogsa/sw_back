using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sw.Entidades.Administracion.TFDs
{
    public class E_TFDsGlobal
    {
        [Key]
        public int IdTFDsGlobal { get; set; }
        public int TotalTFD { get; set; }
        public ICollection<E_TFDsDetalle> e_TFDsDetalles {get; set;}
    }
}
