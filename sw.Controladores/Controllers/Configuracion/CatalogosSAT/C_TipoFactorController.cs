using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.TipoFactor;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_TipoFactorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_TipoFactorController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/C_TipoFactor/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_TipoFactor>> Listar()
        {
            var data = await _context.E_TipoFactors.ToListAsync();


            return data.Select(a => new GET_TipoFactor
            {
                IdTipoFactor = a.IdTipoFactor,
                Clave = a.Clave, 
                Descripcion = a.Descripcion,
                
            });

        }


        // PUT: api/C_TipoFactor/Actualizar
        //[Authorize(Policy = "Policy_TipoFactor_Actualizar")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_TipoFactor model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
    


            var Data = await _context.E_TipoFactors.FirstOrDefaultAsync(a => a.IdTipoFactor == model.IdTipoFactor);

            if (Data == null)
            {
                return NotFound();
            }
            Data.IdTipoFactor = model.IdTipoFactor;
            Data.Descripcion = model.Descripcion;
            Data.Clave = model.Clave;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de factor: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/C_TipoFactor/Crear
        //[Authorize(Policy = "Policy_TipoFactor_Crear")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] POST_TipoFactor model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = ModelState
                });
            }
            var ExistCve = await _context.E_TipoFactors.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_TipoFactors.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un tipo de factor con este nombre: { model.Descripcion}"
                });
            }


            E_TipoFactor tipofactor = new E_TipoFactor
            {
                Descripcion = model.Descripcion,
                Clave = model.Clave, 
            };

            _context.E_TipoFactors.Add(tipofactor);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El tipo de factor: { model.Descripcion } se registro correctamente"
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
