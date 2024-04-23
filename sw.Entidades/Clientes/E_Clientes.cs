using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Administracion.Coorporativo;
 

namespace sw.Entidades.Clientes
{
    public class E_Clientes
    {
        public int IdCliente { get; set; }

        public int E_CoorporativoId { get; set; }
        public E_Coorporativo E_Coorporativo { get; set; }


        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public string Calle { get; set; }
        public string Num_Ext { get; set; }
        public string Num_Int { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string TelFijo { get; set; }
        public string TelMovil { get; set; }
        public string Email { get; set; }
        public Boolean Default { get; set; }
        public double Descuento { get; set; }
    }
}
