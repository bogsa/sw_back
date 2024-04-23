using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Configuracion.CatalogosSAT.FormaPago
{
    public class PUT_FormaPago
    {
        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; set; }
    }
}
