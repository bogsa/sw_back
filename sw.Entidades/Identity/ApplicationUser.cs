using Microsoft.AspNetCore.Identity;
using sw.Entidades.Administracion.CentroTrabajo;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Entidades.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
      : base()
        { }
        public string NombreCompleto { get; set; }
        public Boolean Aprobado { get; set; }
        public string Perfil { get; set; }
        public int E_CentroTrabajoId { get; set; } 
        public E_CentroTrabajo E_CentroTrabajo { get; set; }
    }
}