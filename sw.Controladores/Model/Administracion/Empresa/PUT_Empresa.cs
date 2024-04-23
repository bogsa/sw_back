using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Administracion.Empresa
{
    public class PUT_Empresa
    {
        public int IdEmpresa { get; set; }

        public int E_CoorporativoId { get; set; }

        public int E_RegimenFiscalId { get; set; }

        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string RutaDirectorio { get; set; }
        public string RutaDirectorioVirtual { get; set; }
        public string RutaArchivoCER { get; set; }
        public string RutaArchivoKey { get; set; }
        public string CveKey { get; set; }
        public string RutaLogo { get; set; }
        public int ContadorTimbre { get; set; }
        public string Guid { get; set; }

    }
}
