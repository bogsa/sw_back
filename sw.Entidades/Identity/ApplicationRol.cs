using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Entidades.Identity
{
    public class ApplicationRol : IdentityRole
    {

        public ApplicationRol()
        { }
        public ApplicationRol(string roleName): base(roleName)
        { }
        public ApplicationRol(string roleName, string icono, string color, string tooltip, int prioridad, Boolean activo ) : base(roleName)
        {
            this.Icono = icono;
            this.Color = color; 
            this.Tooltip = tooltip;
            this.Prioridad = prioridad;
            this.Activo = activo;
            
        }

        public string Icono { get; set; }
        public string Color { get; set; }
        public string Tooltip { get; set; }
        public int Prioridad { get; set; }
        public Boolean Activo { get; set; } 

    }
}
