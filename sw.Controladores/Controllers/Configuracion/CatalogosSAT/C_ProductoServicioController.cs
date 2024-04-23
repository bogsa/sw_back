using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.Productoservicio;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_ProductoServicioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_ProductoServicioController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/ProductoServicio/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Productoservicio>> Listar()
        {
            var Producto = await _context.E_ProductoServicios.ToListAsync();
          

            return Producto.Select(a => new GET_Productoservicio
            {
                IdProductoServicio = a.IdProductoServicio,
                Clave = a.Clave,
                Descripcion = a.Descripcion, 
            });

        }


        // PUT: api/ProductoServicio/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        [Authorize(Policy = "Policy_ProductosServicios_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Productoservicio model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            



            var Moneda = await _context.E_ProductoServicios.FirstOrDefaultAsync(a => a.IdProductoServicio == model.IdProductoServicio);

            if (Moneda == null)
            {
                return NotFound();
            }
            Moneda.IdProductoServicio = model.IdProductoServicio;
            Moneda.Clave = model.Clave;
            Moneda.Descripcion = model.Descripcion;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El producto: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/ProductoServicio/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        [Authorize(Policy = "Policy_ProductosServicios_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_Productoservicio model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_ProductoServicios.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_ProductoServicios.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un producto y/o servicio con este nombre: { model.Descripcion}"
                });
            }


            E_ProductoServicio Producto = new E_ProductoServicio
            {
                Clave = model.Clave,
                Descripcion = model.Descripcion,

            };

            _context.E_ProductoServicios.Add(Producto);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El producto y/o servicio: { model.Descripcion } se registro correctamente"
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


    }
}
