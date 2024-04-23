using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Administracion.Coorporativo
{
    public class PUT_Coorporativo
    {
        public int IdCoorporativo { get; set; }
        public string Nombre { get; set; }
        public string Responsable { get; set; }
        public string Direccion { get; set; }
        public string Guid { get; set; }
        public string Telefono { get; set; }
        public Boolean Status { get; set; }
    }
}
