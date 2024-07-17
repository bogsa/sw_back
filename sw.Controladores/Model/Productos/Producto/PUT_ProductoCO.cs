using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Productos.Producto
{
    public class PUT_ProductoCO
    {
        /*--- CONFIGURACION   ---------------------------------------------------------*/
        public int IdProducto { get; set; }  
        public Boolean StatusServicio { get; set; }
        public Boolean ControlaExistencias { get; set; } 
        public Boolean StatusProduccion { get; set; }
        public Boolean LotesCaducidades { get; set; }
        public Boolean Receta { get; set; }
        public Boolean NumerosSerie { get; set; }
        public Boolean Corrida { get; set; }
        public Boolean Paquete { get; set; }

        /*------------------------------------------------------------*/

    }

  
}
