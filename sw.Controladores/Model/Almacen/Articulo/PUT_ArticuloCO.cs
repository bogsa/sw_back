using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Almacen.Articulo
{
    public class PUT_ArticuloCO
    {
        /*--- CONFIGURACION   ---------------------------------------------------------*/
        public int IdArticulo { get; set; }  
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
