using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.TipoComprobante;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_TipoComprobanteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_TipoComprobanteController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/TipoComprobante/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_TipoComprobante>> Listar()
        {
            var Comprobante = await _context.E_TipoComprobante.ToListAsync();
          

            return Comprobante.Select(a => new GET_TipoComprobante
            {
                IdTipoComprobante = a.IdTipoComprobante,
                Clave = a.Clave,
                Descripcion = a.Descripcion, 

            });

        }


        // PUT: api/TipoComprobante/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        //[Authorize(Policy = "Policy_TipoComprobante_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_TipoComprobante model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            


            var Comprobante = await _context.E_TipoComprobante.FirstOrDefaultAsync(a => a.IdTipoComprobante == model.IdTipoComprobante);

            if (Comprobante == null)
            {
                return NotFound();
            }
            Comprobante.IdTipoComprobante = model.IdTipoComprobante;
            Comprobante.Clave = model.Clave;
            Comprobante.Descripcion = model.Descripcion;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de comprobante: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/TipoComprobante/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        //[Authorize(Policy = "Policy_TipoComprobante_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_TipoComprobante model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_TipoComprobante.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un tipo de comprobante con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_TipoComprobante.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un tipo de comprobante con este nombre: { model.Descripcion}"
                });
            }

            E_TipoComprobante Comprobante = new E_TipoComprobante
            {
                Clave = model.Clave,
                Descripcion = model.Descripcion,

            };

            _context.E_TipoComprobante.Add(Comprobante);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de comprobante: { model.Descripcion } se registro correctamente"
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
