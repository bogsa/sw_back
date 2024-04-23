using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.MetodoPago;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_MetodoPagoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_MetodoPagoController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_MetodoPago/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_MetodoPago>> Listar()
        {
            var data = await _context.E_MetodoPagos.ToListAsync();


            return data.Select(a => new GET_MetodoPago
            {
                IdMetodoPago = a.IdMetodoPago,
                Clave = a.Clave, 
                Descripcion = a.Descripcion,
                
            });

        }


        // PUT: api/C_MetodoPago/Actualizar
        //[Authorize(Policy = "Policy_MetodoPago_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_MetodoPago model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
    


            var Data = await _context.E_MetodoPagos.FirstOrDefaultAsync(a => a.IdMetodoPago == model.IdMetodoPago);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdMetodoPago = model.IdMetodoPago;
            Data.Descripcion = model.Descripcion;
            Data.Clave = model.Clave;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La metodo de pago: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/C_MetodoPago/Crear
        //[Authorize(Policy = "Policy_MetodoPago_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_MetodoPago model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            var ExistCve = await _context.E_MetodoPagos.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_MetodoPagos.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un metodo de pago con este nombre: { model.Descripcion}"
                });
            }


            E_MetodoPago metodo = new E_MetodoPago
            {
                Descripcion = model.Descripcion,
                Clave = model.Clave, 
            };

            _context.E_MetodoPagos.Add(metodo);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La metodo de pago: { model.Descripcion } se registro correctamente"
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
