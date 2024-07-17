using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Productos.Producto
{
public class PUT_ProductoDG
    {
        /*---   DATOS GENERALES   ---------------------------------------------------------*/
        public int E_CorporativoId { get; set; }
        public int IdProducto { get; set; } 
        public string Clave { get; set; }
        public string CodigoBarras { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int E_ProductoServicioId { get; set; }
        public int E_CategoriaId { get; set; }
        public string Localizacion { get; set; }
        public int E_ProveedorId { get; set; } 
    }

}