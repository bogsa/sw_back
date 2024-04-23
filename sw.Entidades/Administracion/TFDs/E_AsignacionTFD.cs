using sw.Entidades.Administracion.Empresa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sw.Entidades.Administracion.TFDs
{
    public class E_AsignacionTFD
    {
        [Key]
        public int  IdAsignacionTFDs { get; set; }
        [ForeignKey("E_EmplresaId")]
        public int E_EmpresaId { get; set; }
        public E_Empresa E_Empresa { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public Decimal Precio { get; set; }
        public int CantidadTFD { get; set; }
    }
}
