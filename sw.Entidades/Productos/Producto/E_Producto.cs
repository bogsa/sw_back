using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using sw.Entidades.Productos.Categoria; 
using sw.Entidades.Configuracion.Almacen;
using sw.Entidades.Configuracion.CatalogoSAT;
using sw.Entidades.Productos.Producto;

namespace sw.Entidades.Productos.Producto
{
    public class E_Producto
    {
        /*---   DATOS GENERALES   ---------------------------------------------------------*/
        [Key]
        public int IdProducto { get; set; }
        public Guid IdentificadorUnico { get; set; }

        public string Clave { get; set; }

        public string CodigoBarras { get; set; }

        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public int E_ProductoServicioId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public E_ProductoServicio E_ProductoServicio { get; set; }
        public int E_CategoriaId { get; set; }

        public E_Categoria E_Categoria { get; set; }

        public string Localizacion { get; set; }

        /*---   COSTOS Y PRECIOS   ---------------------------------------------------------*/

        public int E_ProveedorId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public E_Proveedor E_Proveedor { get; set; }
        public int E_UnidadMedidaCId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public E_UnidadMedida E_UnidadMedidaC { get; set; }
        public int E_UnidadMedidaVId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public E_UnidadMedida E_UnidadMedidaV { get; set; }

        public Decimal PrecioCompra { get; set; }
        public Decimal Factor { get; set; }


        /*---   IMPUESTOS   ---------------------------------------------------------*/
        public int E_ObjetoImpuestoId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public E_ObjetoImpuesto E_ObjetoImpuesto { get; set; }
        public string CuentaPredial { get; set; }
        public ICollection<E_ProductoDetalleImpuestos> E_ProductoDetalleImpuestos { get; set; }
        /*--- PRECIOS    ---------------------------------------------------------*/
        public ICollection<E_ProductoDetallePrecios> E_ProductoDetallePrecios { get; set; }


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
