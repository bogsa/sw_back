using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using sw.Entidades.Administracion.CentroTrabajo;
using sw.Entidades.Administracion.Coorporativo;
using sw.Entidades.Configuracion.CatalogoSAT;

namespace sw.Entidades.Administracion.Empresa
{
        public class E_Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        [ForeignKey("E_CoorporativoId")]
        public int E_CoorporativoId { get; set; }
        public E_Coorporativo E_Coorporativo { get; set; }
        [ForeignKey("E_RegimenFiscalId")]
        public int E_RegimenFiscalId { get; set; }
        public E_RegimenFiscal E_RegimenFiscal { get; set; }
        public ICollection<E_CentroTrabajo> E_CentroTrabajos { get; set; }
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
