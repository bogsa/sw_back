using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sw.Entidades.Administracion.Menus
{
    public  class E_SubMenu
    {
        [Key]
        public Guid IdSubMenu { get; set; }
        [ForeignKey("MenuId")]
        public Guid MenuId { get; set; }
        public  E_Menu  Menu { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(80)]
        public string Icono { get; set; }
        [Required]
        [StringLength(200)]
        public string Link { get; set; }
    }
}
