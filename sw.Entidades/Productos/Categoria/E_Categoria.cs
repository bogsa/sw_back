using System;
using System.Collections.Generic;
using System.Text; 
using sw.Entidades.Productos.Categoria;
using sw.Entidades.Productos.Departamento;
using sw.Entidades.Productos.Producto;

namespace sw.Entidades.Productos.Categoria
{
    public class E_Categoria
    {
        public int IdCategoria { get; set; }

        public int E_DepartamentoId { get; set; }
        public E_Departamento E_Departamento { get; set; }

        public string Nombre { get; set; }

        public Boolean Status { get; set; }

        public ICollection<E_Producto> E_Productos { get; set; }
    }
}
