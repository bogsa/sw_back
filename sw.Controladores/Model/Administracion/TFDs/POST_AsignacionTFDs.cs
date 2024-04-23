using System;

namespace sw.Controladores.Model.Administracion.TFDs
{
    public class POST_AsignacionTFDs
    {
        public int E_EmpresaId { get; set; } 
        public Decimal Precio { get; set; }
        public int CantidadTFD { get; set; }
    }
}
