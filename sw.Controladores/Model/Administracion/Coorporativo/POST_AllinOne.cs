using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Administracion.Coorporativo
{
    public class POST_AllinOne
    {

        public string NombreCor { get; set; }
        public string ResponsableCor { get; set; }
        public string DireccionCor { get; set; }
        public string TelefonoCor { get; set; }
        public string GuidCorporativo { get; set; }
        public Boolean CrearCorporativo { get; set; }



        public int E_RegimenFiscalId { get; set; }
        public string NombreEmp { get; set; }
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
        public string GuidEmpresa { get; set; }
        public Boolean CrearEmpresa { get; set; }


        public string NombreSuc { get; set; }
        public string ResponsableSuc { get; set; }
        public string DireccionSuc { get; set; }
        public string TelefonoSuc { get; set; }
        public string Email { get; set; }
        public string Cve_Gerente { get; set; }
        public string Serie { get; set; }
        public int FolioInicial { get; set; }
        public string LugarExpedicion { get; set; }
        public Boolean CrearCentroTrabajo { get; set; }
        public string MensajePersonal { get; set; }
        public string TipoCentroTrabajo { get; set; }

    }
}
