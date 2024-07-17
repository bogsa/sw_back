using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Productos.Categoria
{
    public class POST_Categoria
    {
   
        public string Nombre { get; set; }
        public Boolean Status { get; set; }
        public int E_DepartamentoId { get; set; }
    }
}
