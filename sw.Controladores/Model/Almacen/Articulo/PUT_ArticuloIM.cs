using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Almacen.Articulo
{
    public class PUT_ArticuloIM
    {

        /*---   IMPUESTOS   ---------------------------------------------------------*/
        public int IdArticulo { get; set; }
        public int E_ObjetoImpuestoId { get; set; }
        public string CuentaPredial { get; set; }


    }


}
