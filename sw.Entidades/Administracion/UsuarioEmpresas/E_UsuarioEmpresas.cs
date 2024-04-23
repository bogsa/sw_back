 
using sw.Entidades.Administracion.Empresa;
using sw.Entidades.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sw.Entidades.Administracion.UsuarioEmpresas
{
    public class E_UsuarioEmpresas
    {
        [Key]
        public int IdUsuarioEmpresa { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("E_EmpresaId")]
        public int E_EmpresaId { get; set; }
        public E_Empresa E_Empresa { get; set; }
    }
}
