using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Almacen.Categoria
{
    public class GET_Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public Boolean Status { get; set; } 
        public int E_DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }

        public string NombreCorporativo { get; set; }

    }
}
