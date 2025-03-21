using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using sw.Controladores.Model.Almacen.Inventario;
using sw.Datos;
 


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
            .Include(a => a.E_Producto.E_Categoria)
            .Include(a => a.E_Producto.E_Categoria.E_Departamento)
            .Include(a => a.E_Producto.E_ProductoServicio)
            .Include(a => a.E_Producto.E_Proveedor)
            .Include(a => a.E_Producto.E_UnidadMedidaC)
            .Include(a => a.E_Producto.E_UnidadMedidaV)
            .Include(a => a.E_Producto.E_ObjetoImpuesto)
            .Where(a => a.E_CentroTrabajoId == IdCentroTrabajo)
            .OrderBy(a => a.E_Producto.NombreProducto)
            .ToListAsync();

            return inventario.Select(a => new GET_Inventario
            {
                IdInventario = a.IdInventario,
                E_ProductoId = a.E_ProductoId,
                Existencias = a.Existencias, 
                IdentificadorUnico = a.E_Producto.IdentificadorUnico,
                Clave = a.E_Producto.Clave,
                CodigoBarras = a.E_Producto.CodigoBarras,
                NombreProducto = a.E_Producto.NombreProducto,
                DescripcionProducto = a.E_Producto.DescripcionProducto,
                Marca = a.E_Producto.Marca,
                Modelo = a.E_Producto.Modelo,
                E_ProductoServicioId = a.E_Producto.E_ProductoServicioId,
                ClaveSat = a.E_Producto.E_ProductoServicio.Clave,
                DescripcionCveSat = a.E_Producto.E_ProductoServicio.Descripcion,
                E_CategoriaId = a.E_Producto.E_CategoriaId,
                Categoria = a.E_Producto.E_Categoria.Nombre, 
                E_ProveedorId = a.E_Producto.E_ProveedorId,
                P_nombre = a.E_Producto.E_Proveedor.Nombre,
                P_email = a.E_Producto.E_Proveedor.Email,
                P_telefono = a.E_Producto.E_Proveedor.Telefono,
                P_sitioWeb = a.E_Producto.E_Proveedor.SitioWeb,
                E_UnidadMedidaCId = a.E_Producto.E_UnidadMedidaCId,
                UMC_Clave = a.E_Producto.E_UnidadMedidaC.Clave,
                UMC_Nombre = a.E_Producto.E_UnidadMedidaC.Nombre,
                UMC_Descripcion = a.E_Producto.E_UnidadMedidaC.Descripcion,
                UMC_Nota = a.E_Producto.E_UnidadMedidaC.Nota,
                E_UnidadMedidaVId = a.E_Producto.E_UnidadMedidaVId,
                UMV_Clave = a.E_Producto.E_UnidadMedidaV.Clave,
                UMV_Nombre = a.E_Producto.E_UnidadMedidaV.Nombre,
                UMV_Descripcion = a.E_Producto.E_UnidadMedidaV.Descripcion,
                UMV_Nota = a.E_Producto.E_UnidadMedidaV.Nota,
                PrecioCompra = a.E_Producto.PrecioCompra,
                Factor = a.E_Producto.Factor,
                E_ObjetoImpuestoId = a.E_Producto.E_ObjetoImpuestoId,
                OI_Clave = a.E_Producto.E_ObjetoImpuesto.Clave,
                OI_Descripcion = a.E_Producto.E_ObjetoImpuesto.Descripcion,
                CuentaPredial = a.E_Producto.CuentaPredial,
                StatusServicio = a.E_Producto.StatusServicio,
                ControlaExistencias = a.E_Producto.ControlaExistencias,
                Status = a.E_Producto.Status,
                StatusProduccion = a.E_Producto.StatusProduccion,
                LotesCaducidades = a.E_Producto.LotesCaducidades,
                Receta = a.E_Producto.Receta,
                NumerosSerie = a.E_Producto.NumerosSerie,
                Corrida = a.E_Producto.Corrida,
                Paquete = a.E_Producto.Paquete,
            });

        }
    
        

    }
}
