using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sw.Controladores.Model.Configuracion.CatalogosSAT.UsoCDFI;
using sw.Datos;
using sw.Entidades.Configuracion.CatalogoSAT;

namespace sw.Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "5a67d0af-06a4-4724-8136-7d6989d34123")]
    public class C_UsoCFDIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public C_UsoCFDIController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/UsoCDFI/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GET_UsoCDFI>> Listar()
        {
            var Cfdi = await _context.E_UsoCFDIs
                .ToListAsync();
   
            return Cfdi.Select(a => new GET_UsoCDFI
            {
                IdUsoCFDI = a.IdUsoCFDI,
                Clave = a.Clave,
                Descripcion = a.Descripcion, 
            });

        }


        // PUT: api/UsoCDFI/Actualizar
        //[Authorize(Roles = " Administrador")]
        [HttpPut("[action]")]
        //[Authorize(Policy = "Policy_UsoCFDI_Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] PUT_UsoCDFI model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            




            var Cfdi = await _context.E_UsoCFDIs.FirstOrDefaultAsync(a => a.IdUsoCFDI == model.IdUsoCFDI);

            if (Cfdi == null)
            {
                return NotFound();
            }
            Cfdi.IdUsoCFDI = model.IdUsoCFDI;
            Cfdi.Clave = model.Clave;
            Cfdi.Descripcion = model.Descripcion;


            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"EL uso de CFDI: { model.Descripcion } se actualizo correctamente"
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


        // POST: api/UsoCDFI/Crear
        //[Authorize(Roles = " Administrador")]
        [HttpPost("[action]")]
       // [Authorize(Policy = "Policy_UsoCFDI_Crear")]
        public async Task<IActionResult> Crear([FromBody] POST_UsoCDFI model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistCve = await _context.E_UsoCFDIs.FirstOrDefaultAsync(a => a.Clave == model.Clave);

            if (ExistCve != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe una Clave con esta descripcion: { model.Clave}"
                });
            }

            var ExistDesc = await _context.E_UsoCFDIs.FirstOrDefaultAsync(a => a.Descripcion == model.Descripcion);

            if (ExistDesc != null)
            {
                return BadRequest(new
                {
                    error = $"Ya existe un uso de CFDI con este nombre: { model.Descripcion}"
                });
            }
            E_UsoCFDI Cfdi = new E_UsoCFDI
            {
                Clave = model.Clave,
                Descripcion = model.Descripcion,

            };

            _context.E_UsoCFDIs.Add(Cfdi);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    result = $"El uso de CFDI: { model.Descripcion } se registro correctamente"
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
