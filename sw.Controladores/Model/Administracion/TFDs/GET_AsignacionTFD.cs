
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.TFDs;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Controladores.Administracion.TFDs
{
    public class GET_AsignacionTFD
    {
        public int IdAsignacionTFDs { get; set; }
        public int E_EmpresaId { get; set; } 
        public DateTime FechaAsignacion { get; set; }

        public Decimal Precio { get; set; }
        public int CantidadTFD { get; set; }

        public string NombreEmpresa { get; set; }
        public string RFC { get; set; }
    }
}
