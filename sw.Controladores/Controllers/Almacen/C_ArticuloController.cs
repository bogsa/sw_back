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
using sw.Datos;
using sw.Entidades.Almacen.Articulo;
using sw.Entidades.Almacen.Inventario;


namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_ArticuloController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_ArticuloController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/C_Articulo/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Articulo>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var articulo = await _context.E_Articulo
            .Include(a => a.E_Categoria)
            .Include(a => a.E_Categoria.E_Departamento)
            .Include(a => a.E_ProductoServicio)
            .Include(a => a.E_Proveedor)
            .Include(a => a.E_UnidadMedidaC)
            .Include(a => a.E_UnidadMedidaV)
            .Include(a => a.E_ObjetoImpuesto)
            .Where(a => a.E_Categoria.E_Departamento.E_CorporativoId == IdCorporativo)
            .OrderBy(a => a.NombreArticulo)
            .ToListAsync();



            return articulo.Select(a => new GET_Articulo

            {
                IdArticulo = a.IdArticulo,
                IdentificadorUnico = a.IdentificadorUnico,
                Clave = a.Clave,
                CodigoBarras = a.CodigoBarras,
                NombreArticulo = a.NombreArticulo,
                DescripcionArticulo = a.DescripcionArticulo,
                Marca = a.Marca,
                Modelo = a.Modelo,
                E_ProductoServicioId = a.E_ProductoServicioId,
                ClaveSat = a.E_ProductoServicio.Clave,
                DescripcionCveSat = a.E_ProductoServicio.Descripcion,
                E_CategoriaId = a.E_CategoriaId,
                Categoria = a.E_Categoria.Nombre,
                Localizacion = a.Localizacion,
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
        // GET: api/C_Articulo/ListarDetPreciosArticulo
        [HttpGet("[action]/{IdArticulo}")]
        public async Task<IEnumerable<GET_InventarioDetallePrecios>> ListarDetPreciosArticulo([FromRoute] int IdArticulo)
        {
            var inventarioDetP = await _context.E_InventarioDetallePrecios
           .Where(a => a.E_InventarioId == IdArticulo)
            .ToListAsync();

            return inventarioDetP.Select(a => new GET_InventarioDetallePrecios
            {
                IdInventarioDetallePrecios = a.IdInventarioDetallePrecios,
                PrecioVenta = a.PrecioVenta,
                Cantidad = a.Cantidad,
                MargenUtilidad = a.MargenUtilidad,

            });

        }

        // GET: api/C_Articulo/ListarDetImpuestosArticulo
        [HttpGet("[action]/{IdArticulo}")]
        public async Task<IEnumerable<GET_ArticuloDetalleImpuestos>> ListarDetImpuestosArticulo([FromRoute] int IdArticulo)
        {
            var articuloDetI = await _context.E_ArticuloDetalleImpuestos
            .Where(a => a.E_ArticuloId == IdArticulo)
            .ToListAsync();

            return articuloDetI.Select(a => new GET_ArticuloDetalleImpuestos
            {
                IdArticuloDetalleImpuestos = a.IdArticuloDetalleImpuestos,
                TipoImpuesto = a.TipoImpuesto,
                Impuesto = a.Impuesto,
                TipoFactor = a.TipoFactor,
                Valor = a.Valor,

            });

        }

        // POST: api/C_Articulo/Crear 
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Articulo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_Articulo
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
            var ExistCodBarras = await _context.E_Articulo
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

            E_Articulo Articulo = new E_Articulo
            {
                IdentificadorUnico = Guid.NewGuid(),
                Clave = model.Clave,
                CodigoBarras = model.CodigoBarras,
                NombreArticulo = model.NombreArticulo,
                DescripcionArticulo = model.DescripcionArticulo,
                Marca = model.Marca,
                Modelo = model.Modelo,
                E_ProductoServicioId = model.E_ProductoServicioId,
                E_CategoriaId = model.E_CategoriaId,
                E_ProveedorId = model.E_ProveedorId,
                Localizacion = model.Localizacion,
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
                _context.E_Articulo.Add(Articulo);
                await _context.SaveChangesAsync();

                var idArticulo = Articulo.IdArticulo;


                foreach (var detI in model.POST_ArticuloDetalleImpuestos)
                {
                    E_ArticuloDetalleImpuestos detalleI = new E_ArticuloDetalleImpuestos
                    {
                        E_ArticuloId = idArticulo,
                        TipoImpuesto = detI.TipoImpuesto,
                        Impuesto = detI.Impuesto,
                        TipoFactor = detI.TipoFactor,
                        Valor = detI.Valor,
                    };
                    _context.E_ArticuloDetalleImpuestos.Add(detalleI);

                }


                foreach (var inventario in model.POST_Inventario)
                {
                    E_Inventario detalleInv = new E_Inventario
                    {
                        E_CentroTrabajoId = inventario.E_CentroTrabajoId,
                        E_ArticuloId = inventario.E_ArticuloId,
                        Existencias = 0,
                    };
                    _context.E_Inventarios.Add(detalleInv);

                    foreach (var invCP in model.POST_InventarioDetallePrecios)
                    {
                        E_InventarioDetallePrecios detalleCP  = new E_InventarioDetallePrecios
                        {
                            E_InventarioId = detalleInv.IdInventario,
                            PrecioVenta =  invCP.PrecioVenta,
                            Cantidad = invCP.CantidadMayoreo,
                            MargenUtilidad = invCP.MargenUtilidad,
                        };
                        _context.E_InventarioDetallePrecios.Add(detalleCP);    
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

        // PUT: api/C_Articulo/Desactivar/1
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

            var articulo = await _context.E_Articulo.FirstOrDefaultAsync(c => c.IdArticulo == id);

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

        // PUT: api/C_Articulo/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest(new
                {
                    error = "El ID  del articulo no existe"
                });
            }

            var articulo = await _context.E_Articulo.FirstOrDefaultAsync(c => c.IdArticulo == id);

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
                    result = "El artículo se activo correctamente"
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
        // PUT: api/C_Articulo/ActualizarDG
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarDG([FromBody] PUT_ArticuloDG model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Articulo.FirstOrDefaultAsync(a => a.IdArticulo == model.IdArticulo);

            if (a == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_Articulo
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
            var ExistCodBarras = await _context.E_Articulo
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

            a.Clave = model.Clave;
            a.CodigoBarras = model.CodigoBarras;
            a.NombreArticulo = model.NombreArticulo;
            a.DescripcionArticulo = model.DescripcionArticulo;
            a.Marca = model.Marca;
            a.Modelo = model.Modelo;
            a.E_ProductoServicioId = model.E_ProductoServicioId;
            a.E_CategoriaId = model.E_CategoriaId;
            a.Localizacion = model.Localizacion;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "Los datos generales del artículo se actualizarón correctamente"
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
        // PUT: api/C_Articulo/ActualizarDG
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        public async Task<IActionResult> ActualizarCP([FromBody] PUT_InventarioCP model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Articulo.FirstOrDefaultAsync(a => a.IdArticulo == model.IdArticulo);

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
                    result = "Los datos compras y precios del artículo se actualizarón correctamente"
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

        // POST: api/C_Articulo/CrearDetallePC
        [HttpPost("[action]")]
        public async Task<IActionResult> CrearDetallePC([FromBody] POST_InventarioDetallePrecios model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            E_InventarioDetallePrecios detalleCP = new E_InventarioDetallePrecios
            {
                E_InventarioId = model.E_InventarioId,
                PrecioVenta = model.PrecioVenta,
                Cantidad = model.CantidadMayoreo,
                MargenUtilidad = model.MargenUtilidad,

            };
            _context.E_InventarioDetallePrecios.Add(detalleCP);

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

        // DELETE: api/C_Articulo/EliminarPC
        [HttpDelete("[action]/{IdArticuloDetallePrecios}")]
        public async Task<IActionResult> EliminarPC([FromRoute] int IdArticuloDetallePrecios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detallePC = await _context.E_InventarioDetallePrecios.FindAsync(IdArticuloDetallePrecios);
            if (detallePC == null)
            {
                return NotFound();
            }

            _context.E_InventarioDetallePrecios.Remove(detallePC);
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
        public async Task<IActionResult> CrearDetalleIM([FromBody] POST_ArticuloDetalleImpuestos model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            E_ArticuloDetalleImpuestos detalleIM = new E_ArticuloDetalleImpuestos
            {
                E_ArticuloId = model.E_ArticuloId,
                TipoImpuesto = model.TipoImpuesto,
                Impuesto = model.Impuesto,
                TipoFactor = model.TipoFactor,
                Valor = model.Valor,

            };
            _context.E_ArticuloDetalleImpuestos.Add(detalleIM);

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
        // DELETE: api/C_Articulo/EliminarIM
        [HttpDelete("[action]/{IdArticuloDetalleImpuestos}")]
        public async Task<IActionResult> EliminarIM([FromRoute] int IdArticuloDetalleImpuestos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalleIM = await _context.E_ArticuloDetalleImpuestos.FindAsync(IdArticuloDetalleImpuestos);
            if (detalleIM == null)
            {
                return NotFound();
            }

            _context.E_ArticuloDetalleImpuestos.Remove(detalleIM);
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
        public async Task<IActionResult> ActualizarIM([FromBody] PUT_ArticuloIM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Articulo.FirstOrDefaultAsync(a => a.IdArticulo == model.IdArticulo);

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
                    result = "Los impuestos del artículo se actualizarón correctamente"
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
        public async Task<IActionResult> ActualizarCO([FromBody] PUT_ArticuloCO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var a = await _context.E_Articulo.FirstOrDefaultAsync(a => a.IdArticulo == model.IdArticulo);

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
                    result = "La configuración del artículo se actualizo correctamete."
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
