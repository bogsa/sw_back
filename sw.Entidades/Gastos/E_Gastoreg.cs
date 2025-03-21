using sw.Entidades.Administracion.CentroTrabajo;
using sw.Entidades.Configuracion.Gastos;
using sw.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sw.Entidades.Gastos
{
    public class E_Gastoreg
    {

        
        public int IdGastoreg { get; set; }
        public Decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int E_CentroTrabajoId { get; set; }
        public E_CentroTrabajo E_CentroTrabajo { get; set; }

        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        
        public int E_GastoId { get; set; }
        public E_Gasto E_Gasto { get; set; }

    }
}
