using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.RegimenFiscal;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_RegimenFiscalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_RegimenFiscalController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/RegimenFiscal/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_RegimenFiscal>> Listar()
        {
            var Regimen = await _context.E_RegimenFiscals
                .OrderBy(a => a.Clave)
                .ToListAsync();
         

            return Regimen.Select(a => new GET_RegimenFiscal
            {
                IdRegimenFiscal = a.IdRegimenFiscal,
                Clave = a.Clave,
                Descripcion = a.Descripcion, 

            });

        }


        // PUT: api/RegimenFiscal/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
      //  [Authorize(Policy = "Policy_RegimenFiscal_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_RegimenFiscal model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            var Regimen = await _context.E_RegimenFiscals.FirstOrDefaultAsync(a => a.IdRegimenFiscal == model.IdRegimenFiscal);

            if (Regimen == null)
            {
                return NotFound();
            }
            Regimen.IdRegimenFiscal = model.IdRegimenFiscal;
            Regimen.Clave = model.Clave;
            Regimen.Descripcion = model.Descripcion;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El régimen fiscal: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/RegimenFiscal/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
     //   [Authorize(Policy = "Policy_RegimenFiscal_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_RegimenFiscal model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_RegimenFiscals.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un régimen fiscal con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_RegimenFiscals.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un régimen fiscal con este nombre: { model.Descripcion}"
                });
            }

            E_RegimenFiscal Regimen = new E_RegimenFiscal
            {
                Clave = model.Clave,
                Descripcion = model.Descripcion,

            };

            _context.E_RegimenFiscals.Add(Regimen);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"La régimen fiscal: { model.Descripcion } se registro correctamente"
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
