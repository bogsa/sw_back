using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Configuracion.CatalogoSAT;
using sw.Entidades.Clientes.Cliente;


namespace sw.Entidades.Clientes.ClienteDatoFiscal
{
    public class E_ClienteDatosFiscales
    {
        public int IdClienteDatosFiscales { get; set; }

        public int E_ClienteId { get; set; }
        public E_Clientes Clientes { get; set; }

        public int E_RegimenFiscalId { get; set; }
        public E_RegimenFiscal RegimenFiscal { get; set; }

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

        public string TelMovil { get; set; }



    }
}
