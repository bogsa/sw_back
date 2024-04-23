using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.FormaPago;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_FormaPagoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_FormaPagoController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_FormaPago/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_FormaPago>> Listar()
        {
            var data = await _context.E_FormaPago.ToListAsync();


            return data.Select(a => new GET_FormaPago
            {
                IdFormaPago = a.IdFormaPago,
                Clave = a.Clave, 
                Descripcion = a.Descripcion,
                
            });

        }


        // PUT: api/C_FormaPago/Actualizar
        [Authorize(Policy = "Policy_FormaPago_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_FormaPago model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
    


            var Data = await _context.E_FormaPago.FirstOrDefaultAsync(a => a.IdFormaPago == model.IdFormaPago);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdFormaPago = model.IdFormaPago;
            Data.Descripcion = model.Descripcion;
            Data.Clave = model.Clave;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La forma de pago: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/C_FormaPago/Crear
        //[Authorize(Policy = "Policy_FormaPago_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_FormaPago model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            var ExistCve = await _context.E_FormaPago.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_FormaPago.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una forma de pago con este nombre: { model.Descripcion}"
                });
            }


            E_FormaPago Forma = new E_FormaPago
            {
                Descripcion = model.Descripcion,
                Clave = model.Clave, 
            };

            _context.E_FormaPago.Add(Forma);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La forma de pago:  { model.Descripcion } se registro correctamente"
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
