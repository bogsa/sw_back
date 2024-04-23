using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.TipoRelacion; 
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_TipoRelacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_TipoRelacionController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/TipoRelacion/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_TipoRelacion>> Listar()
        {
            var Forma = await _context.E_TipoRelacions
                .OrderBy(a => a.Clave)
                .ToListAsync();
       

            return Forma.Select(a => new GET_TipoRelacion
            {
                IdTipoRelacion = a.IdTipoRelacion,
                Descripcion = a.Descripcion,
                Clave = a.Clave,  
            });

        }


        // PUT: api/C_TipoRelacion/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        //[Authorize(Policy = "Policy_TipoRelacion_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_TipoRelacion model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            


            var Tipo = await _context.E_TipoRelacions.FirstOrDefaultAsync(a => a.IdTipoRelacion == model.IdTipoRelacion);

            if (Tipo == null)
            {
                return NotFound();
            }
            Tipo.IdTipoRelacion = model.IdTipoRelacion;
            Tipo.Descripcion = model.Descripcion;
            Tipo.Clave = model.Clave;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de relacion: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/C_TipoRelacion/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
       // [Authorize(Policy = "Policy_TipoRelacion_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_TipoRelacion model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_TipoRelacions.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_TipoRelacions.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un tipo de relacion con este nombre: { model.Descripcion}"
                });
            }

            E_TipoRelacion Tipo = new E_TipoRelacion
            {
                Descripcion = model.Descripcion,
                Clave = model.Clave,


            };

            _context.E_TipoRelacions.Add(Tipo);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de relacion: { model.Descripcion } se registro correctamente"
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
