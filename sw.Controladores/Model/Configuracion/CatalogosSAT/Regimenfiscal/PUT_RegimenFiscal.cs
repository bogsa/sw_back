using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Configuracion.CatalogosSAT.RegimenFiscal
{
    public class PUT_RegimenFiscal
    {
        public int IdRegimenFiscal { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
    }
}
