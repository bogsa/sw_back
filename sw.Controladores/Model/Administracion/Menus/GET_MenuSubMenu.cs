using System;
using System.Collections.Generic;

namespace sw.Controladores.Model.Administracion.Menus
{
    public class GET_MenuSubMenu
    {
        public Guid Id { get; set; }
        public Guid RolId { get; set; }
        public string Titulo { get; set; }
        public string Icono { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
        public List<GET_SubMenu> SubMenus  { get; set; }

    }
}
