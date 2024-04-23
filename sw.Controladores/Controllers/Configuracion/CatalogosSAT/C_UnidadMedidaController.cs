using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
using System.Collections.Generic;
using System;
using sw.Datos;
using sw.Controladores.Model.Configuracion.CatalogosSAT.UnidadMedida;
using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_UnidadMedidaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_UnidadMedidaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/UnidadMedida/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_UnidadMedida>> Listar()
        {
            var Unidad = await _context.E_UnidadMedidas 
                .ToListAsync();
            

            return Unidad.Select(a => new GET_UnidadMedida
            {
                IdUnidadMedida = a.IdUnidadMedida,
                Clave = a.Clave,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion, 
                Nota = a.Nota,

            });

        }


        // PUT: api/UnidadMedida/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        [Authorize(Policy = "Policy_UnidadMedida_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_UnidadMedida model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
 

            var Unidad = await _context.E_UnidadMedidas.FirstOrDefaultAsync(a => a.IdUnidadMedida == model.IdUnidadMedida);

            if (Unidad == null)
            {
                return NotFound();
            }
            Unidad.IdUnidadMedida = model.IdUnidadMedida;
            Unidad.Clave = model.Clave;
            Unidad.Nombre = model.Nombre;
            Unidad.Descripcion = model.Descripcion;
            Unidad.Nota = model.Nota;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = "El registro  se actualizo correctamente"
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


        // POST: api/UnidadMedida/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
        [Authorize(Policy = "Policy_UnidadMedida_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_UnidadMedida model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_UnidadMedidas.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            

            E_UnidadMedida Unidad = new E_UnidadMedida
            {
                Clave = model.Clave,
                Nombre= model.Nombre,
                Descripcion = model.Descripcion,
                Nota= model.Nota,

            };

            _context.E_UnidadMedidas.Add(Unidad);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La unidad de medida: { model.Descripcion } se registro correctamente"
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
