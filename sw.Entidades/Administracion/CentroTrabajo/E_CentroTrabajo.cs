using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using sw.Entidades.Administracion.Empresa;

namespace sw.Entidades.Administracion.CentroTrabajo
{
    public class E_CentroTrabajo
    {
        [Key]
        public int IdCentroTrabajo { get; set; }
        [ForeignKey("E_EmpresaId")]
        public int E_EmpresaId { get; set; }
        public E_Empresa E_Empresa { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Responsable { get; set; }
        [StringLength(200)]
        public string Direccion { get; set; }
        [StringLength(12)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string Cve_Gerente { get; set; }
        [StringLength(5)]
        public string Serie { get; set; }
        public Boolean Activo { get; set; }
        public int FolioInicial { get; set; }
        public string LugarExpedicion { get; set; }
        public string MensajePersonal { get; set; }
        public string TipoCentroTrabajo { get; set; }

    }
}
