using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sw.Entidades.Administracion.Menus
{
    public class E_Menu
    {
        [Key]
        public Guid IdMenu { get; set; }
        public Guid IdRol { get; set; }
        public string Titulo { get; set; }
        public string Icono { get; set; }
        public ICollection<E_SubMenu> e_SubMenus { get; set; }
         
    }
}
