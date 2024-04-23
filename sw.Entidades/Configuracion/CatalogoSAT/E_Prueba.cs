using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sw.Entidades.Configuracion.CatalogoSAT
{
    public class E_Prueba
    {
        [Key]
        public int IdPrueba { get; set; }
 
        public string Descripcion { get; set; }
 
    }
}
