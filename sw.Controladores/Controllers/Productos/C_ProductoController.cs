using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Productos.Producto;
using sw.Controladores.Model.Productos.Categoria;
using sw.Datos; 
using sw.Entidades.Almacen.Inventario;
using sw.Entidades.Productos.Producto;


namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/C_Producto/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Producto>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var productos = await _context.E_Producto
            .Include(a => a.E_Categoria)
            .Include(a => a.E_Categoria.E_Departamento)
            .Include(a => a.E_ProductoServicio)
            .Include(a => a.E_Proveedor)
            .Include(a => a.E_UnidadMedidaC)
            .Include(a => a.E_UnidadMedidaV)
            .Include(a => a.E_ObjetoImpuesto)
            .Where(a => a.E_Categoria.E_Departamento.E_CorporativoId == IdCorporativo)
            .OrderBy(a => a.NombreProducto)
            .ToListAsync();



            return productos.Select(a => new GET_Producto

            {
                IdProducto = a.IdProducto,
                IdentificadorUnico = a.IdentificadorUnico,
                Clave = a.Clave,
                CodigoBarras = a.CodigoBarras,
                NombreProducto = a.NombreProducto,
                DescripcionProducto = a.DescripcionProducto,
                Marca = a.Marca,
                Modelo = a.Modelo,
                E_ProductoServicioId = a.E_ProductoServicioId,
                ClaveSat = a.E_ProductoServicio.Clave,
                DescripcionCveSat = a.E_ProductoServicio.Descripcion,
                E_CategoriaId = a.E_CategoriaId,
                Categoria = a.E_Categoria.Nombre, 
                E_ProveedorId = a.E_ProveedorId,
                P_nombre = a.E_Proveedor.Nombre,
                P_email = a.E_Proveedor.Email,
                P_telefono = a.E_Proveedor.Telefono,
                P_sitioWeb = a.E_Proveedor.SitioWeb,
                E_UnidadMedidaCId = a.E_UnidadMedidaCId,
                UMC_Clave = a.E_UnidadMedidaC.Clave,
                UMC_Nombre = a.E_UnidadMedidaC.Nombre,
                UMC_Descripcion = a.E_UnidadMedidaC.Descripcion,
                UMC_Nota = a.E_UnidadMedidaC.Nota,
                E_UnidadMedidaVId = a.E_UnidadMedidaVId,
                UMV_Clave = a.E_UnidadMedidaV.Clave,
                UMV_Nombre = a.E_UnidadMedidaV.Nombre,
                UMV_Descripcion = a.E_UnidadMedidaV.Descripcion,
                UMV_Nota = a.E_UnidadMedidaV.Nota,
                PrecioCompra = a.PrecioCompra,
                Factor = a.Factor,
                E_ObjetoImpuestoId = a.E_ObjetoImpuestoId,
                OI_Clave = a.E_ObjetoImpuesto.Clave,
                OI_Descripcion = a.E_ObjetoImpuesto.Descripcion,
                CuentaPredial = a.CuentaPredial,
                StatusServicio = a.StatusServicio,
                ControlaExistencias = a.ControlaExistencias,
                Status = a.Status,
                StatusProduccion = a.StatusProduccion,
                LotesCaducidades = a.LotesCaducidades,
                Receta = a.Receta,
                NumerosSerie = a.NumerosSerie,
                Corrida = a.Corrida,
                Paquete = a.Paquete,
            });

        }
        // GET: api/C_Producto/ListarDetPreciosProducto
        [HttpGet("[action]/{IdProcuto}")]
        public async Task<IEnumerable<GET_ProductoDetallePrecios>> ListarDetPreciosProducto([FromRoute] int IdProducto)
        {
            var inventarioDetP = await _context.E_ProductoDetallePrecios
           .Where(a => a.E_ProductoId == IdProducto)
            .ToListAsync();

            return inventarioDetP.Select(a => new GET_ProductoDetallePrecios
            {
                IdProductoDetallePrecios = a.IdProductoDetallePrecios,
                PrecioVenta = a.PrecioVenta,
                CantidadMayor = a.CantidadMayor,
                MargenUtilidad = a.MargenUtilidad,

            });

        }

        // GET: api/C_Producto/ListarDetImpuestosProducto
        [HttpGet("[action]/{IdProducto}")]
        public async Task<IEnumerable<GET_ProductoDetalleImpuestos>> ListarDetImpuestosArticulo([FromRoute] int IdProducto)
        {
            var articuloDetI = await _context.E_ProductoDetalleImpuestos
            .Where(a => a.E_ProductoId == IdProducto)
            .ToListAsync();

            return articuloDetI.Select(a => new GET_ProductoDetalleImpuestos
            {
                IdProductoDetalleImpuestos = a.IdProductoDetalleImpuestos,
                TipoImpuesto = a.TipoImpuesto,
                Impuesto = a.Impuesto,
                TipoFactor = a.TipoFactor,
                Valor = a.Valor,

            });

        }

        // POST: api/C_Producto/Crear 
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Producto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_Producto
                                .Where(a => a.Clave == model.Clave)
                                .Where(a => a.E_Categoria.E_Departamento.E_CorporativoId == model.E_CorporativoId)
                                .FirstOrDefaultAsync();

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un articulo con la clave: {model.Clave}"
                });
            }
            var ExistCodBarras = await _context.E_Producto
                                .Where(a => a.CodigoBarras == model.CodigoBarras)
                                .Where(a => a.E_Categoria.E_Departamento.E_CorporativoId == model.E_CorporativoId)
                                .FirstOrDefaultAsync();

            if (ExistCodBarras != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un articulo con este codigo de barras: {model.CodigoBarras}"
                });
            }

            E_Producto Producto = new E_Producto
            {
                IdentificadorUnico = Guid.NewGuid(),
                Clave = model.Clave,
                CodigoBarras = model.CodigoBarras,
                NombreProducto = model.NombreProducto,
                DescripcionProducto = model.DescripcionProducto,
                Marca = model.Marca,
                Modelo = model.Modelo,
                E_ProductoServicioId = model.E_ProductoServicioId,
                E_CategoriaId = model.E_CategoriaId,
                E_ProveedorId = model.E_ProveedorId, 
                E_UnidadMedidaCId = model.E_UnidadMedidaCId,
                E_UnidadMedidaVId = model.E_UnidadMedidaVId,
                PrecioCompra = model.PrecioCompra,
                Factor = model.Factor,
                E_ObjetoImpuestoId = model.E_ObjetoImpuestoId,
                CuentaPredial = model.CuentaPredial,
                StatusServicio = model.StatusServicio,
                ControlaExistencias = model.ControlaExistencias,
                Status = true,
                StatusProduccion = model.StatusProduccion,
                LotesCaducidades = model.LotesCaducidades,
                Receta = model.Receta,
                NumerosSerie = model.NumerosSerie,
                Corrida = model.Corrida,
                Paquete = model.Paquete,
            };


            try
            {
                _context.E_Producto.Add(Producto);
                await _context.SaveChangesAsync();

                var idArticulo = Producto.IdProducto;


                foreach (var detI in model.POST_ProductoDetalleImpuestos)
                {
                    E_ProductoDetalleImpuestos detalleI = new E_ProductoDetalleImpuestos
                    {
                        E_ProductoId = idArticulo,
                        TipoImpuesto = detI.TipoImpuesto,
                        Impuesto = detI.Impuesto,
                        TipoFactor = detI.TipoFactor,
                        Valor = detI.Valor,
                    };
                    _context.E_ProductoDetalleImpuestos.Add(detalleI);

                }


                foreach (var inventario in model.POST_Inventario)
                {
                    E_Inventario detalleInv = new E_Inventario
                    {
                        E_CentroTrabajoId = inventario.E_CentroTrabajoId,
                        E_ProductoId = inventario.E_ProductoId,
                        Existencias = 0,
                    };
                    _context.E_Inventarios.Add(detalleInv);

                    foreach (var invCP in model.POST_ProductoDetallePrecios)
                    {
                        E_ProductoDetallePrecios detalleCP  = new E_ProductoDetallePrecios
                        {
                            E_ProductoId = detalleInv.IdInventario,
                            PrecioVenta =  invCP.PrecioVenta,
                            CantidadMayor = invCP.CantidadMayoreo,
                            MargenUtilidad = invCP.MargenUtilidad,
                        };
                        _context.E_ProductoDetallePrecios.Add(detalleCP);    
                    }

                }

                await _context.SaveChangesAsync();




                return Ok(new
                {
                    result = "La artículo se registro correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar crear el registro"
                });
            }


        }

        // PUT: api/C_Producto/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest(new
                {
                    error = "El ID del artículo no existe"
                });
            }

            var articulo = await _context.E_Producto.FirstOrDefaultAsync(c => c.IdProducto == id);

            if (articulo == null)
            {
                return NotFound();
            }

            articulo.Status = false;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El artículo se de deshabilito correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar deshabilitar el articulo"
                });
            }


        }

        // PUT: api/C_Producto/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest(new
                {
                    error = "El ID  del producto no existe"
                });
            }

            var articulo = await _context.E_Producto.FirstOrDefaultAsync(c => c.IdProducto == id);

            if (articulo == null)
            {
                return NotFound();
            }

            articulo.Status = true;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El producto se activo correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar activar el artículo"
                });
            }
        }
        // PUT: api/C_Producto/ActualizarDG
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarDG([FromBody] PUT_ProductoDG model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Producto.FirstOrDefaultAsync(a => a.IdProducto == model.IdProducto);

            if (a == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_Producto
                                .Where(a => a.Clave == model.Clave)
                                .Where(a => a.E_Categoria.E_Departamento.E_CorporativoId == model.E_CorporativoId)
                                .FirstOrDefaultAsync();

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un producto con la clave: {model.Clave}"
                });
            }
            var ExistCodBarras = await _context.E_Producto
                                .Where(a => a.CodigoBarras == model.CodigoBarras)
                                .Where(a => a.E_Categoria.E_Departamento.E_CorporativoId == model.E_CorporativoId)
                                .FirstOrDefaultAsync();

            if (ExistCodBarras != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un producto con este codigo de barras: {model.CodigoBarras}"
                });
            }

            a.Clave = model.Clave;
            a.CodigoBarras = model.CodigoBarras;
            a.NombreProducto = model.NombreProducto;
            a.DescripcionProducto = model.DescripcionProducto;
            a.Marca = model.Marca;
            a.Modelo = model.Modelo;
            a.E_ProductoServicioId = model.E_ProductoServicioId;
            a.E_CategoriaId = model.E_CategoriaId; 

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "Los datos generales del producto se actualizarón correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar actualizar el registro"
                });
            }


        }
        // PUT: api/C_Producto/ActualizarDG
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarCP([FromBody] PUT_InventarioCP model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Producto.FirstOrDefaultAsync(a => a.IdProducto== model.IdProducto);

            if (a == null)
            {
                return NotFound();
            }

            a.E_UnidadMedidaCId = model.E_UnidadMedidaCId;
            a.E_UnidadMedidaVId = model.E_UnidadMedidaVId;
            a.PrecioCompra = model.PrecioCompra;
            a.Factor = model.Factor;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "Los datos compras y precios del producto se actualizarón correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar actualizar el registro"
                });
            }


        }

        // POST: api/C_Producto/CrearDetallePC
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearDetallePC([FromBody] POST_InventarioDetallePrecios model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            E_ProductoDetallePrecios detalleCP = new E_ProductoDetallePrecios
            {
                E_ProductoId = model.E_InventarioId,
                PrecioVenta = model.PrecioVenta,
                CantidadMayor = model.CantidadMayoreo,
                MargenUtilidad = model.MargenUtilidad,

            };
            _context.E_ProductoDetallePrecios.Add(detalleCP);

            try
            {
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    result = "La producto se registro correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar crear el registro"
                });
            }
        }

        // DELETE: api/C_Producto/EliminarPC
        [HttpDelete("[action]/{IdProductoDetallePrecios}")]
        public async Task<IActionResult> EliminarPC([FromRoute] int IdProductoDetallePrecios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detallePC = await _context.E_ProductoDetallePrecios.FindAsync(IdProductoDetallePrecios);
            if (detallePC == null)
            {
                return NotFound();
            }

            _context.E_ProductoDetallePrecios.Remove(detallePC);
            try
            {
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    result = "El detalle del precio se elminio correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar eliminar el registro"
                });
            }
        }
        // POST: api/C_Articulo/CrearDetalleIM
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearDetalleIM([FromBody] POST_ProductoDetalleImpuestos model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            E_ProductoDetalleImpuestos detalleIM = new E_ProductoDetalleImpuestos
            {
                E_ProductoId = model.E_ProductoId,
                TipoImpuesto = model.TipoImpuesto,
                Impuesto = model.Impuesto,
                TipoFactor = model.TipoFactor,
                Valor = model.Valor,

            };
            _context.E_ProductoDetalleImpuestos.Add(detalleIM);

            try
            {
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    result = "La artículo se registro correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar crear el registro"
                });
            }
        }
        // DELETE: api/C_Producto/EliminarIM
        [HttpDelete("[action]/{IdArticuloDetalleImpuestos}")]
        public async Task<IActionResult> EliminarIM([FromRoute] int IdArticuloDetalleImpuestos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalleIM = await _context.E_ProductoDetalleImpuestos.FindAsync(IdArticuloDetalleImpuestos);
            if (detalleIM == null)
            {
                return NotFound();
            }

            _context.E_ProductoDetalleImpuestos.Remove(detalleIM);
            try
            {
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    result = "El detalle del precio se elminio correctamente"
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    error = "Error al intentar eliminar el registro"
                });
            }
        }

        // PUT: api/C_Articulo/ActualizarIM
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarIM([FromBody] PUT_ProductoIM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Producto.FirstOrDefaultAsync(a => a.IdProducto == model.IdProducto);

            if (a == null)
            {
                return NotFound();
            }

            a.E_ObjetoImpuestoId = model.E_ObjetoImpuestoId;
            a.CuentaPredial = model.CuentaPredial;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "Los impuestos del producto se actualizarón correctamente"
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar actualizar el registro"
                });
            }


        }
        // PUT: api/C_Articulo/ActualizarIM
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarCO([FromBody] PUT_ProductoCO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Producto.FirstOrDefaultAsync(a => a.IdProducto == model.IdProducto);

            if (a == null)
            {
                return NotFound();
            }

            a.StatusServicio = model.StatusServicio;
            a.ControlaExistencias = model.ControlaExistencias;
            a.StatusProduccion = model.StatusProduccion;
            a.LotesCaducidades = model.LotesCaducidades;
            a.Receta = model.Receta;
            a.NumerosSerie = model.NumerosSerie;
            a.Corrida = model.Corrida;
            a.Paquete = model.Paquete;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "La configuración del producto se actualizo correctamete."
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest(new
                {
                    error = "Error al intentar actualizar el registro"
                });
            }

        }


    }
}
