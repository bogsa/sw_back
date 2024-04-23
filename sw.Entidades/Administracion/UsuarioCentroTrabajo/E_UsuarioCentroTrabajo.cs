using sw.Entidades;
using sw.Entidades.Administracion.CentroTrabajo;
using sw.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sw.Entidades.Administracion.UsuarioCentroTrabajoes
{
    public class E_UsuarioCentroTrabajoes
    {
        [Key]
        public int IdUsuarioCentroTrabajo { get; set; }
        [ForeignKey("UserId")]
        public string  UserId { get; set; }
        public ApplicationUser  User { get; set; }
        [ForeignKey("E_CentroTrabajoId")]
        public int E_CentroTrabajoId { get; set; }
        public E_CentroTrabajo E_CentroTrabajo { get; set; }
    }
}
