using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Almacen.Articulo
{
  public class GET_Articulo
  {
    /*---   DATOS GENERALES   ---------------------------------------------------------*/
    public int IdArticulo { get; set; }
    public Guid IdentificadorUnico { get; set; }
    public string Clave { get; set; }
    public string CodigoBarras { get; set; }
    public string NombreArticulo { get; set; }
    public string DescripcionArticulo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int E_ProductoServicioId { get; set; }
    public string ClaveSat { get; set; }
    public string DescripcionCveSat { get; set; }
    public int E_CategoriaId { get; set; }
    public string Categoria { get; set; }
    public string Localizacion { get; set; }

    /*---   COSTOS Y PRECIOS   ---------------------------------------------------------*/
    public int E_ProveedorId { get; set; }
    public string P_nombre { get; set; }
    public string P_email { get; set; }
    public string P_telefono { get; set; }
    public string P_sitioWeb { get; set; }
    public int E_UnidadMedidaCId { get; set; }
    public string UMC_Clave { get; set; }
    public string UMC_Nombre { get; set; }
    public string UMC_Descripcion { get; set; }
    public string UMC_Nota { get; set; }
    public int E_UnidadMedidaVId { get; set; }
    public string UMV_Clave { get; set; }
    public string UMV_Nombre { get; set; }
    public string UMV_Descripcion { get; set; }
    public string UMV_Nota { get; set; }
    public Decimal PrecioCompra { get; set; }
    public Decimal Factor { get; set; }
    /*---   IMPUESTOS   ---------------------------------------------------------*/
    public int E_ObjetoImpuestoId { get; set; }
    public string OI_Clave { get; set; }
    public string OI_Descripcion { get; set; }
    public string CuentaPredial { get; set; }

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
