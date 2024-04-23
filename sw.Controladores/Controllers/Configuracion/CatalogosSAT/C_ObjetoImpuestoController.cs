using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.ObjetoImpuesto;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_ObjetoImpuestoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_ObjetoImpuestoController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_ObjetoImpuesto/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_ObjetoImpuesto>> Listar()
        {
            var data = await _context.E_ObjetoImpuestos.ToListAsync();


            return data.Select(a => new GET_ObjetoImpuesto
            {
                IdObjetoImpuesto = a.IdObjetoImpuesto,
                Clave = a.Clave, 
                Descripcion = a.Descripcion,
                
            });

        }


        // PUT: api/C_ObjetoImpuesto/Actualizar
       // [Authorize(Policy = "Policy_ObjetoImpuesto_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_ObjetoImpuesto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
    


            var Data = await _context.E_ObjetoImpuestos.FirstOrDefaultAsync(a => a.IdObjetoImpuesto == model.IdObjetoImpuesto);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdObjetoImpuesto = model.IdObjetoImpuesto;
            Data.Descripcion = model.Descripcion;
            Data.Clave = model.Clave;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El objeto de impuesto: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/C_ObjetoImpuesto/Crear
       // [Authorize(Policy = "Policy_ObjetoImpuesto_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_ObjetoImpuesto model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            var ExistCve = await _context.E_ObjetoImpuestos.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_ObjetoImpuestos.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un objeto de impuesto con este nombre: { model.Descripcion}"
                });
            }


            E_ObjetoImpuesto objetoimp = new E_ObjetoImpuesto
            {
                Descripcion = model.Descripcion,
                Clave = model.Clave, 
            };

            _context.E_ObjetoImpuestos.Add(objetoimp);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El objeto de impuesto: { model.Descripcion } se registro correctamente"
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
