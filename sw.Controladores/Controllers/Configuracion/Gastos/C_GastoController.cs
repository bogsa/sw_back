using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.Gastos;
using sw.Datos;
using sw.Entidades.Configuracion.Gastos;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_GastoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public C_GastoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/C_Gasto/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Gasto>> Listar()
        {
            var data = await _context.E_Gastos.ToListAsync();


            return data.Select(a => new GET_Gasto
            {
                IdGasto = a.IdGasto,
                Descripcion = a.Descripcion,

            });

        }


        // PUT: api/C_Gasto/Actualizar
        //[Authorize(Policy = "Policy_Gasto_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Gasto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }



            var Data = await _context.E_Gastos.FirstOrDefaultAsync(a => a.IdGasto == model.IdGasto);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdGasto = model.IdGasto;
            Data.E_CorporativoId = model.E_CorporativoId;
            Data.Descripcion = model.Descripcion;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de gasto: {model.Descripcion} se actualizo correctamente"
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


        // POST: api/C_Gasto/Crear
        //[Authorize(Policy = "Policy_Gasto_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_Gasto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }


            var ExistDesc = await _context.E_Gastos.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion && a.E_CorporativoId==model.E_CorporativoId);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un tipo de gasto con este nombre: {model.Descripcion}"
                });
            }


            E_Gasto gasto = new E_Gasto
            {
                Descripcion = model.Descripcion,
                E_CorporativoId = model.E_CorporativoId,
            };

            _context.E_Gastos.Add(gasto);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de gasto: {model.Descripcion} se registro correctamente"
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


        // GET: api/C_Gasto/ListarporCorporativo
        [HttpGet("[action]/{IdCorporativo}")]
        public async Task<IEnumerable<GET_Gasto>> ListarporCorporativo([FromRoute] int IdCorporativo)
        {
            var Gasto = await _context.E_Gastos
            .OrderBy(a => a.Descripcion)
            .Where(a => a.E_CorporativoId == IdCorporativo)
            .ToListAsync();



            return Gasto.Select(a => new GET_Gasto
            {
                IdGasto = a.IdGasto,
                E_CorporativoId = a.E_CorporativoId,
                Descripcion = a.Descripcion,

            });

        }


    }
}
