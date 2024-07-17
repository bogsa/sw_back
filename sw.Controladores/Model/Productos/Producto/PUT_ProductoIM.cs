using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Productos.Producto
{
    public class PUT_ProductoIM
    {

        /*---   IMPUESTOS   ---------------------------------------------------------*/
        public int IdProducto { get; set; }
        public int E_ObjetoImpuestoId { get; set; }
        public string CuentaPredial { get; set; }


    }


}
