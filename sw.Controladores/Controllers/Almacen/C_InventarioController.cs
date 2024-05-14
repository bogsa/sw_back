using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Almacen.Articulo;
using sw.Controladores.Model.Almacen.Categoria;
using sw.Controladores.Model.Almacen.Inventario;
using sw.Datos;
using sw.Entidades.Articulos.Articulo;


namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_InventarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_InventarioController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/C_Articulo/ListarporCorporativo
        [HttpGet("[action]/{IdCentroTrabajo}")]
        public async Task<IEnumerable<GET_Inventario>> ListarporCentroTrabajo([FromRoute] int IdCentroTrabajo)
        {
            var inventario= await _context.E_Inventarios
            .Include(a => a.E_Articulo.E_Categoria)
            .Include(a => a.E_Articulo.E_Categoria.E_Departamento)
            .Include(a => a.E_Articulo.E_ProductoServicio)
            .Include(a => a.E_Articulo.E_Proveedor)
            .Include(a => a.E_Articulo.E_UnidadMedidaC)
            .Include(a => a.E_Articulo.E_UnidadMedidaV)
            .Include(a => a.E_Articulo.E_ObjetoImpuesto)
            .Where(a => a.E_CentroTrabajoId == IdCentroTrabajo)
            .OrderBy(a => a.E_Articulo.NombreArticulo)
            .ToListAsync();

            return inventario.Select(a => new GET_Inventario
            {
                IdInventario = a.IdInventario,
                E_ArticuloId = a.E_ArticuloId,
                Existencias = a.Existencias,

                IdentificadorUnico = a.E_Articulo.IdentificadorUnico,
                Clave = a.E_Articulo.Clave,
                CodigoBarras = a.E_Articulo.CodigoBarras,
                NombreArticulo = a.E_Articulo.NombreArticulo,
                DescripcionArticulo = a.E_Articulo.DescripcionArticulo,
                Marca = a.E_Articulo.Marca,
                Modelo = a.E_Articulo.Modelo,
                E_ProductoServicioId = a.E_Articulo.E_ProductoServicioId,
                ClaveSat = a.E_Articulo.E_ProductoServicio.Clave,
                DescripcionCveSat = a.E_Articulo.E_ProductoServicio.Descripcion,
                E_CategoriaId = a.E_Articulo.E_CategoriaId,
                Categoria = a.E_Articulo.E_Categoria.Nombre,
                Localizacion = a.E_Articulo.Localizacion,
                E_ProveedorId = a.E_Articulo.E_ProveedorId,
                P_nombre = a.E_Articulo.E_Proveedor.Nombre,
                P_email = a.E_Articulo.E_Proveedor.Email,
                P_telefono = a.E_Articulo.E_Proveedor.Telefono,
                P_sitioWeb = a.E_Articulo.E_Proveedor.SitioWeb,
                E_UnidadMedidaCId = a.E_Articulo.E_UnidadMedidaCId,
                UMC_Clave = a.E_Articulo.E_UnidadMedidaC.Clave,
                UMC_Nombre = a.E_Articulo.E_UnidadMedidaC.Nombre,
                UMC_Descripcion = a.E_Articulo.E_UnidadMedidaC.Descripcion,
                UMC_Nota = a.E_Articulo.E_UnidadMedidaC.Nota,
                E_UnidadMedidaVId = a.E_Articulo.E_UnidadMedidaVId,
                UMV_Clave = a.E_Articulo.E_UnidadMedidaV.Clave,
                UMV_Nombre = a.E_Articulo.E_UnidadMedidaV.Nombre,
                UMV_Descripcion = a.E_Articulo.E_UnidadMedidaV.Descripcion,
                UMV_Nota = a.E_Articulo.E_UnidadMedidaV.Nota,
                PrecioCompra = a.E_Articulo.PrecioCompra,
                Factor = a.E_Articulo.Factor,
                E_ObjetoImpuestoId = a.E_Articulo.E_ObjetoImpuestoId,
                OI_Clave = a.E_Articulo.E_ObjetoImpuesto.Clave,
                OI_Descripcion = a.E_Articulo.E_ObjetoImpuesto.Descripcion,
                CuentaPredial = a.E_Articulo.CuentaPredial,
                StatusServicio = a.E_Articulo.StatusServicio,
                ControlaExistencias = a.E_Articulo.ControlaExistencias,
                Status = a.E_Articulo.Status,
                StatusProduccion = a.E_Articulo.StatusProduccion,
                LotesCaducidades = a.E_Articulo.LotesCaducidades,
                Receta = a.E_Articulo.Receta,
                NumerosSerie = a.E_Articulo.NumerosSerie,
                Corrida = a.E_Articulo.Corrida,
                Paquete = a.E_Articulo.Paquete,
            });

        }
    
        

    }
}
