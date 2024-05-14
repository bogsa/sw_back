using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Articulos.Articulo;
using sw.Entidades.Articulos.Categoria;
using sw.Entidades.Articulos.Departamento;

namespace sw.Entidades.Articulos.Categoria
{
    public class E_Categoria
    {
        public int IdCategoria { get; set; }

        public int E_DepartamentoId { get; set; }
        public E_Departamento E_Departamento { get; set; }

        public string Nombre { get; set; }

        public Boolean Status { get; set; }

        public ICollection<E_Articulo> E_Articulos { get; set; }
    }
}
