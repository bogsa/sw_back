using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.Moneda;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_MonedaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_MonedaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_Moneda/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_Moneda>> Listar()
        {
            var Moneda = await _context.E_Moneda.ToListAsync();

            int aux = 0;

            int conteo()
            {
                aux += 1;
                return aux;
            }

            return Moneda.Select(a => new GET_Moneda
            {
                IdMoneda = a.IdMoneda,
                Clave = a.Clave,
                Descripcion = a.Descripcion,
                Numeracion = conteo()

            });

        }


        // PUT: api/C_Moneda/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        //[Authorize(Policy = "Policy_Monedas_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_Moneda model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            var Moneda = await _context.E_Moneda.FirstOrDefaultAsync(a => a.IdMoneda == model.IdMoneda);

            if (Moneda == null)
            {
                return NotFound();
            }
            Moneda.IdMoneda = model.IdMoneda;
            Moneda.Clave = model.Clave;
            Moneda.Descripcion = model.Descripcion;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La moneda: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/C_Moneda/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
       // [Authorize(Policy = "Policy_Monedas_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_Moneda model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_Moneda.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_Moneda.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una moneda con este nombre: { model.Descripcion}"
                });
            }

            E_Moneda Moneda = new E_Moneda
            {
                Clave = model.Clave,
                Descripcion = model.Descripcion,

            };

            _context.E_Moneda.Add(Moneda);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La moneda: { model.Descripcion } se registro correctamente"
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
