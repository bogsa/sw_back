using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace sw.Controladores.Model.Productos.Producto
{
    public class POST_Producto
    {
      /*---   DATOS GENERALES   ---------------------------------------------------------*/
        public int E_CorporativoId { get; set; }
        public Guid IdentificadorUnico { get; set; }
        public string Clave { get; set; }
        public string CodigoBarras { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int E_ProductoServicioId { get; set; }
        public int E_CategoriaId { get; set; }
        public string Localizacion { get; set; }
    
        /*---   COSTOS Y PRECIOS   ---------------------------------------------------------*/
        public int E_ProveedorId { get; set; }
 
        public int E_UnidadMedidaCId  { get; set; }
        public int E_UnidadMedidaVId  { get; set; }
        public Decimal PrecioCompra { get; set; }
        public Decimal Factor { get; set; }

        public List<POST_Inventario> POST_Inventario { get; set; }
        public List<POST_InventarioDetallePrecios> POST_ProductoDetallePrecios { get; set; }
        /*---   IMPUESTOS   ---------------------------------------------------------*/
        public int E_ObjetoImpuestoId { get; set; }
        public string CuentaPredial { get; set; } 
        public List<POST_ProductoDetalleImpuestos> POST_ProductoDetalleImpuestos { get; set; }
        
        /*--- CONFIGURACION   ---------------------------------------------------------*/

        public Boolean StatusServicio { get; set; }
        public Boolean ControlaExistencias { get; set; }
        public Boolean Status { get; set; }
        public Boolean StatusProduccion { get; set; }
        public Boolean LotesCaducidades { get; set; }
        public Boolean Receta { get; set; }
        public Boolean NumerosSerie { get; set; }
        public Boolean Corrida { get; set; }
        public Boolean Paquete { get; set; }

        /*------------------------------------------------------------*/

    }

  
}
