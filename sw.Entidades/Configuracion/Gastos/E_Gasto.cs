using sw.Entidades.Administracion.Coorporativo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sw.Entidades.Configuracion.Gastos
{
    public class E_Gasto
    {
        
        public int IdGasto { get; set; }
        public string Descripcion { get; set; }

        public int E_CorporativoId { get; set; }
        public  E_Coorporativo E_Corporativo { get; set; }


         
    }
}
